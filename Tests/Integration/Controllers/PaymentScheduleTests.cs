﻿public class PaymentScheduleTests(IMediator mediator, IMessageRequests messageRequests, IEntitlementRepository entitlementRepository, ILoggerFactory loggerFactory)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<PaymentScheduleTests>();

    // NOTE not a practical integration test, used to speed up the development of PaymentController.SchedulePayment service
    [Fact]
    public async Task Schedule_Payment()
    {
        var cadCurrencyCommand = new GetCurrencyLookupCommand();
        var cadCurrency = await mediator.Send(cadCurrencyCommand);

        var teamQuery = new SingleTeamQuery();
        teamQuery.Name = "CVAP Administrative Team";
        teamQuery.TeamType = TeamType.Owner;
        var adminTeam = await mediator.Send(teamQuery);
        if (adminTeam == null)
        {
            throw new Exception("CVAP Admin Team not found.");
        }

        var incomeSupportParameterQuery = new SingleIncomeSupportParameterQuery();
        incomeSupportParameterQuery.Type = IncomeSupportParameterType.MinimumWage;
        incomeSupportParameterQuery.BeforeEffectiveDate = DateTime.Today;
        incomeSupportParameterQuery.StateCode = StateCode.Active;
        incomeSupportParameterQuery.StatusCode = IncomeSupportParameterStatusCode.Active;
        incomeSupportParameterQuery.Validated = YesNo.Yes;
        var minimumWage = await mediator.Send(incomeSupportParameterQuery);

        var paymentScheduleQuery = new PaymentScheduleEntitlementQuery();
        paymentScheduleQuery.PaymentScheduleQuery = new PaymentScheduleQuery();
        paymentScheduleQuery.PaymentScheduleQuery.StateCode = StateCode.Active;
        paymentScheduleQuery.PaymentScheduleQuery.BeforeStartDate = DateTime.Now;
        paymentScheduleQuery.PaymentScheduleQuery.BeforeNextRunDate = DateTime.Now;
        paymentScheduleQuery.PaymentScheduleQuery.NotNullCaseId = true;
        paymentScheduleQuery.PaymentScheduleQuery.NotNullPayeeId = true;
        paymentScheduleQuery.EntitlementQuery = new EntitlementQuery();
        paymentScheduleQuery.EntitlementQuery.StatusCode = EntitlementStatusCode.Approved;
        paymentScheduleQuery.EntitlementQuery.PaymentScheduleStatus = PaymentScheduleStatus.Active;
        paymentScheduleQuery.EntitlementQuery.IsRecurring = true;

        var paymentScheduleEntitlements = await mediator.Send(paymentScheduleQuery);
        foreach (var paymentScheduleEntitlement in paymentScheduleEntitlements)
        {
            var paymentSchedule = paymentScheduleEntitlement.PaymentSchedule;
            var entitlement = paymentScheduleEntitlement.Entitlement;

            if (paymentSchedule.NextRunDate == null)
                continue;
            var oldRunTime = paymentSchedule.NextRunDate.Value.ToLocalTime(); //OnOrBefore operator doesn't look at time and only looks at date.
            if (oldRunTime > DateTime.Now)
                continue;

            if (entitlement.SetCap == null)
                continue;

            if (paymentSchedule.EndDate != null)
            {
                var endDate = paymentSchedule.EndDate.Value.ToLocalTime();
                if (endDate < DateTime.Now)
                {
                    // update entitlement to have payment schedule status "Inactive" (Cancelled)
                    _logger.LogInformation(string.Format("Updating Payment Schedule Status to Inactive for '{0}'..", entitlement.Id));
                    entitlementRepository.UpdatePaymentScheduleStatus(entitlement.Id, PaymentScheduleStatus.Cancelled);

                    messageRequests.SetState(Vsd_PaymentSchedule.EntityLogicalName, paymentScheduleEntitlement.PaymentSchedule.Id, 1, 2);
                }
            }

            #region Create Invoice & Payment

            var invoice = new Invoice() { Owner = new DynamicReference(adminTeam.Id, Database.Model.Team.EntityLogicalName) };
            _logger.LogInformation("Entering into Invoice creation");
            invoice.Id = Guid.NewGuid();
            invoice.Origin = Origin.AutoGenerated;
            invoice.CvapInvoiceType = InvoiceType.OtherPayments;
            invoice.InvoiceDate = DateTime.Now;
            invoice.Payee = paymentSchedule.Payee;
            invoice.CaseId = paymentSchedule.CaseId;
            invoice.EntitlementId = paymentSchedule.EntitlementId;
            invoice.CvapAuthorizationStatus = CvapAuthorizationStatus.ApprovedByQr;
            invoice.AuthorizationDate = DateTime.Now;
            invoice.ProgramUnit = ProgramUnit.Cvap;
            invoice.CurrencyId = cadCurrency.Id;
            invoice.CvapPaymentType = CvapPaymentType.PostAdjudication; // 100000001
            invoice.StatusCode = InvoiceStatusCode.Submitted;
            invoice.MethodOfPayment = MethodOfPayment.Cheque;
            invoice.CvapNumberOfLineItems = CvapNumberOfLineItems._1; //100000000 //1
            invoice.CvapStobId = Constant.CvapStobId; //7902 - Entitlements
            invoice.ProcessId = Guid.Empty;
            invoice.ProvinceStateId = Constant.ProvinceBc;
            invoice.PaymentScheduleId = paymentSchedule.Id;
            invoice.CpuInvoiceType = CpuInvoiceType.ScheduledPayment;
            if (entitlement.TaxExemptFlag ?? false)
                invoice.TaxExemption = TaxExemption.NoTax;
            else
                invoice.TaxExemption = TaxExemption.GstOnly;

            var getPaymentTotalCommand = new GetPaymentTotalCommand
            {
                PaymentSchedule = paymentSchedule,
                Entitlement = entitlement
            };
            getPaymentTotalCommand.MinimumWage = minimumWage.Value;
            var paymentAmounts = await mediator.Send(getPaymentTotalCommand);

            var payment = new Payment();
            payment.Date = DateTime.Now;
            if (entitlement.TaxExemptFlag ?? false)
            {
                payment.SubTotal = paymentAmounts.Amount;
                payment.Total = payment.SubTotal;
            }
            else
            {
                var bcProvinceQuery = new FindProvinceQuery();
                bcProvinceQuery.Id = Constant.ProvinceBc;
                var bcProvince = await mediator.Send(bcProvinceQuery);
                ArgumentNullException.ThrowIfNull(bcProvince.TaxRate);

                payment.SubTotal = paymentAmounts.Amount;
                payment.Gst = (decimal)payment.SubTotal * (decimal)bcProvince.TaxRate;
                payment.Total = (decimal)payment.SubTotal + payment.Gst;
            }

            payment.GlDate = DateTime.Now;
            payment.Terms = PaymentTerms.Immediate;
            payment.CaseId = paymentSchedule.CaseId;
            payment.EntitlementId = paymentSchedule.EntitlementId;
            //paymentEntity["ownerid"] = adminTeam;
            payment.Payee = invoice.Payee;
            payment.TransactionCurrencyId = cadCurrency.Id;
            payment.EftAdvice = EftAdvice.Mail;

            //VS-5752
            payment.RemittanceMessage1 = paymentSchedule.CaseName;
            payment.RemittanceMessage2 = invoice.EntitlementName;   // e.g. "Income Support-Long term-Minimum Wage"
            payment.RemittanceMessage3 = "Crime Victim Assistance Program";

            //****Add Line Item
            var invoiceLineDetail = new InvoiceLineDetail()
            {
                Owner = invoice.Owner
            };
            invoiceLineDetail.Id = Guid.NewGuid();
            invoiceLineDetail.CaseId = invoice.CaseId;
            invoiceLineDetail.EntitlementId = invoice.EntitlementId;
            invoiceLineDetail.InvoiceId = invoice.Id;
            invoiceLineDetail.AmountSimple = payment.SubTotal;
            invoiceLineDetail.InvoiceType = InvoiceType.OtherPayments;
            invoiceLineDetail.Approved = YesNo.Yes;
            invoiceLineDetail.ProvinceStateId = Constant.ProvinceBc;
            invoiceLineDetail.TaxExemption = invoice.TaxExemption;
            invoiceLineDetail.ProgramUnit = ProgramUnit.Cvap;
            invoiceLineDetail.CurrencyId = cadCurrency.Id;
            invoice.InvoiceLineDetails = new List<InvoiceLineDetail> { invoiceLineDetail };

            payment.Invoices = new List<Invoice>() { invoice };

            var insertPaymentCommand = new InsertCommand<Payment>(payment);
            payment.Id = await mediator.Send(insertPaymentCommand);

            // TODO try adding payment before invoice and then no update required
            invoice.PaymentId = payment.Id;

            #endregion

            #region Update Next Run Time
            //****Check for weekdays
            var getNextRuntimeCommand = new GetNextRuntimeCommand
            {
                PaymentSchedule = paymentSchedule
            };
            var nextRunDate = await mediator.Send(getNextRuntimeCommand);

            bool deactivateNextRun = false;
            if (paymentSchedule.EndDate != null)
            {
                var endDate = ((DateTime)paymentSchedule.EndDate).ToLocalTime();
                if (endDate <= nextRunDate)
                {
                    _logger.LogInformation("Deactivating payment schedule due to end date is earlier than next run date");
                    deactivateNextRun = true;   //VS-6245: if enddate is earlier or equals to next run date then deactivate the schedule 
                                                //  continue;   //removed due to VS-6245
                }
            }

            _logger.LogInformation("Updating the Next Run Date and total income support amount..");
            //var updatePaymentSchedule = new PaymentSchedule();
            //updatePaymentSchedule.Id = paymentSchedule.Id;
            if (paymentSchedule.FirstRunDate == null)
                paymentSchedule.FirstRunDate = paymentSchedule.NextRunDate;
            paymentSchedule.TotalAmountOfIncomeSupport = paymentAmounts.Amount;

            if (deactivateNextRun == true)    //VS-6245
            {
                paymentSchedule.StateCode = StateCode.Inactive;
                paymentSchedule.StatusCode = PaymentScheduleStatusCode.Inactive;
            }
            else
            {
                paymentSchedule.NextRunDate = nextRunDate;
            }

            paymentSchedule.ActualValue = paymentAmounts.ActualAmount;

            //Added new logic//VS-4531.
            if (paymentSchedule.OverPaymentEmi != null && paymentSchedule.OverPaymentAmount != null)
            {
                var overPayment = paymentSchedule.OverPaymentAmount;
                var emi = paymentSchedule.OverPaymentEmi;

                if ((overPayment - emi) >= 0)
                {
                    paymentSchedule.RemainingPaymentAmount = overPayment - emi;
                }
                else if ((overPayment - emi) < 0)
                {
                    paymentSchedule.RemainingPaymentAmount = 0;
                }
            }

            var updatePaymentScheduleCommand = new UpdateCommand<PaymentSchedule>(paymentSchedule);
            await mediator.Send(updatePaymentScheduleCommand);

            #endregion
        }
    }
}