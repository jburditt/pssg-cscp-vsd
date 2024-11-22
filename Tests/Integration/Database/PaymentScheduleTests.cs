public class PaymentScheduleTests(IMediator mediator, IMessageRequests messageRequests, IEntitlementRepository entitlementRepository, ILoggerFactory loggingFactory)
{
    private readonly ILogger _logger = loggingFactory.CreateLogger<PaymentScheduleTests>();

    // NOTE not a practical integration test, used to speed up the development of PaymentController.SchedulePayment service
    [Fact]
    public async Task Schedule_Payment()
    {
        var teamQuery = new SingleTeamQuery();
        teamQuery.Name = "CVAP Administrative Team";
        teamQuery.TeamType = TeamType.Owner;
        var team = await mediator.Send(teamQuery);
        if (team == null)
        {
            throw new Exception("CVAP Admin Team not found.");
        }

        var incomeSupportParamterQuery = new SingleIncomeSupportParameterQuery();
        incomeSupportParamterQuery.Type = IncomeSupportParameterType.MinimumWage;
        incomeSupportParamterQuery.BeforeEffectiveDate = DateTime.Today;
        incomeSupportParamterQuery.StateCode = StateCode.Active;
        incomeSupportParamterQuery.StatusCode = IncomeSupportParameterStatusCode.Active;
        incomeSupportParamterQuery.Validated = YesNo.Yes;
        var minimumWage = await mediator.Send(incomeSupportParamterQuery);

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

            //var entitlementEntity = OrgService.Retrieve("vsd_entitlement", ((EntityReference)paymentScheduleEntity["vsd_entitlementid"]).Id, new ColumnSet(true));

            //#region Create Invoice & Payment
            //Entity invoiceEntity = new Entity("vsd_invoice");
            //Log.AppendLine("Entering into Invoice creation");
            //invoiceEntity.Id = Guid.NewGuid();
            //invoiceEntity["vsd_origin"] = new OptionSetValue(100000002); //Auto-Generated
            //invoiceEntity["vsd_cvap_invoicetype"] = new OptionSetValue(100000001); //Other Payments
            //invoiceEntity["vsd_invoicedate"] = DateTime.Now;
            //invoiceEntity["vsd_payee"] = paymentScheduleEntity["vsd_payee"];
            //invoiceEntity["vsd_caseid"] = paymentScheduleEntity["vsd_caseid"];
            //invoiceEntity["ownerid"] = adminTeam;
            //invoiceEntity["vsd_entitlementid"] = paymentScheduleEntity["vsd_entitlementid"];
            //invoiceEntity["vsd_cvap_authorizationstatus"] = new OptionSetValue(100000001); //Approved by QR
            //invoiceEntity["vsd_authorizationdate"] = DateTime.Now;
            //invoiceEntity["vsd_programunit"] = new OptionSetValue(100000000); //CVAP
            //invoiceEntity["transactioncurrencyid"] = currencyLookup;
            //invoiceEntity["vsd_cvap_paymenttype"] = new OptionSetValue(100000001); //Post-Adjudication
            //invoiceEntity["statuscode"] = new OptionSetValue(100000000); //Submitted
            //invoiceEntity["vsd_methodofpayment"] = new OptionSetValue(100000001); //Cheque
            //invoiceEntity["vsd_cvap_numberoflineitems"] = new OptionSetValue(100000000); //1
            //invoiceEntity["vsd_cvap_stobid"] = new EntityReference("vsd_cvapstob", new Guid("38c0dc94-7120-eb11-b821-00505683fbf4")); //7902 - Entitlements
            //invoiceEntity["processid"] = Guid.Empty;
            //invoiceEntity["vsd_cvap_numberoflineitems"] = new OptionSetValue(100000000); //1
            //invoiceEntity["vsd_provincestateid"] = new EntityReference("vsd_province", new Guid("FDE4DBCA-989A-E811-8155-480FCFF4F6A1")); //BC
            //invoiceEntity["vsd_paymentscheduleid"] = paymentScheduleEntity.ToEntityReference();
            //if ((bool)((AliasedValue)paymentScheduleEntity["ent.vsd_taxexemptflag"]).Value)
            //    invoiceEntity["vsd_taxexemption"] = new OptionSetValue(100000002); //No Tax
            //else
            //    invoiceEntity["vsd_taxexemption"] = new OptionSetValue(100000001); //GST Only

            //var paymentAmounts = GetPaymentTotal(paymentScheduleEntity, entitlementEntity, minimumWage);

            //Entity paymentEntity = new Entity("vsd_payment");
            //paymentEntity["vsd_paymentdate"] = DateTime.Now;
            //if ((bool)((AliasedValue)paymentScheduleEntity["ent.vsd_taxexemptflag"]).Value)
            //{
            //    paymentEntity["vsd_paymentsubtotal"] = paymentAmounts.Item1;
            //    paymentEntity["vsd_paymenttotal"] = paymentEntity["vsd_paymentsubtotal"];
            //}
            //else
            //{
            //    var bcProvinceEntity = OrgService.Retrieve("vsd_province", new Guid("FDE4DBCA-989A-E811-8155-480FCFF4F6A1"), new ColumnSet("vsd_taxrate")); //GST
            //    if (!bcProvinceEntity.Contains("vsd_taxrate"))
            //        throw new InvalidPluginExecutionException("GST is empty on BC Province..");

            //    paymentEntity["vsd_paymentsubtotal"] = paymentAmounts.Item1;
            //    paymentEntity["vsd_gst"] = new Money(((Money)paymentEntity["vsd_paymentsubtotal"]).Value * (decimal)bcProvinceEntity["vsd_taxrate"]);
            //    paymentEntity["vsd_paymenttotal"] = new Money(((Money)paymentEntity["vsd_paymentsubtotal"]).Value + ((Money)paymentEntity["vsd_gst"]).Value);
            //}

            //paymentEntity["vsd_gldate"] = DateTime.Now;
            //paymentEntity["vsd_terms"] = new OptionSetValue(100000001); //"Immediate";
            //paymentEntity["vsd_case"] = paymentScheduleEntity["vsd_caseid"];
            //paymentEntity["vsd_entitlementid"] = paymentScheduleEntity["vsd_entitlementid"];
            ////paymentEntity["ownerid"] = adminTeam;
            //paymentEntity["vsd_payee"] = invoiceEntity["vsd_payee"];
            //paymentEntity["transactioncurrencyid"] = currencyLookup;
            //paymentEntity["vsd_eftadvice"] = new OptionSetValue(100000001); //Mail

            ////VS-5752
            //paymentEntity["vsd_remittancemessage1"] = ((EntityReference)paymentScheduleEntity["vsd_caseid"]).Name;
            //paymentEntity["vsd_remittancemessage2"] = ((EntityReference)invoiceEntity["vsd_entitlementid"]).Name;
            //paymentEntity["vsd_remittancemessage3"] = "Crime Victim Assistance Program";

            ////****Add Line Item
            //Entity lineEntity = new Entity("vsd_invoiceid");
            ////lineEntity["vsd_name"] = ((EntityReference)paymentScheduleEntity["vsd_entitlementid"]).Name;
            //lineEntity["vsd_caseid"] = invoiceEntity["vsd_caseid"];
            //lineEntity["vsd_entitlementid"] = invoiceEntity["vsd_entitlementid"];
            //lineEntity["vsd_invoiceid"] = invoiceEntity.ToEntityReference();
            ////lineEntity["ownerid"] = adminTeam;
            //lineEntity["vsd_amountsimple"] = paymentEntity["vsd_paymentsubtotal"];
            //lineEntity["vsd_invoicetype"] = new OptionSetValue(100000001); //Other Payments
            //lineEntity["vsd_lineitemapproved"] = new OptionSetValue(100000001); //Yes
            //lineEntity["vsd_provincestateid"] = new EntityReference("vsd_province", new Guid("FDE4DBCA-989A-E811-8155-480FCFF4F6A1")); //BC
            //lineEntity["vsd_taxexemption"] = (OptionSetValue)invoiceEntity["vsd_taxexemption"];
            //lineEntity["vsd_programunit"] = new OptionSetValue(100000000); //CVAP
            //lineEntity["transactioncurrencyid"] = currencyLookup;

            //EntityCollection lineCollection = new EntityCollection();
            //lineCollection.EntityName = "vsd_invoicelinedetail";
            //lineCollection.Entities.Add(lineEntity);
            //Relationship lineRelationship = new Relationship("vsd_vsd_invoice_vsd_invoicelinedetail");
            //invoiceEntity.RelatedEntities.Add(lineRelationship, lineCollection);

            //EntityCollection invoiceCollection = new EntityCollection();
            //invoiceCollection.EntityName = "vsd_invoice";
            //invoiceCollection.Entities.Add(invoiceEntity);
            //Relationship invoiceRelationship = new Relationship("vsd_vsd_payment_vsd_invoice");
            //paymentEntity.RelatedEntities.Add(invoiceRelationship, invoiceCollection);

            //paymentEntity.Id = OrgService.Create(paymentEntity);

            //Entity updateInvoice = new Entity("vsd_invoice");
            //updateInvoice.Id = invoiceEntity.Id;
            //updateInvoice["vsd_paymentid"] = paymentEntity.ToEntityReference();
            //OrgService.Update(updateInvoice);

            //#endregion

            //#region Update Next Run Time
            ////****Check for weekdays
            //var nextRunDate = GetNextRuntime(paymentScheduleEntity);

            //bool deactivateNextRun = false;
            //if (paymentScheduleEntity.Contains("vsd_enddate") && paymentScheduleEntity["vsd_enddate"] != null)
            //{
            //    var endDate = ((DateTime)paymentScheduleEntity["vsd_enddate"]).ToLocalTime();
            //    if (endDate <= nextRunDate)
            //    {
            //        Log.AppendLine("Deactivating payment schedule due to end date is earlier than next run date");
            //        deactivateNextRun = true;   //VS-6245: if enddate is earlier or equals to next run date then deactivate the schedule 
            //                                    //  continue;   //removed due to VS-6245
            //    }
            //}

            //Log.AppendLine("Updating the Next Run Date and total income support amount..");
            //Entity updatePaymentSchedule = new Entity("vsd_paymentschedule");
            //updatePaymentSchedule.Id = paymentScheduleEntity.Id;
            //if (!paymentScheduleEntity.Contains("vsd_firstrundate"))
            //    updatePaymentSchedule["vsd_firstrundate"] = paymentScheduleEntity["vsd_nextrundate"];
            //updatePaymentSchedule["vsd_totalamountofincomesupport"] = paymentAmounts.Item1;

            //if (deactivateNextRun == true)    //VS-6245
            //{
            //    updatePaymentSchedule["statecode"] = new OptionSetValue(1); //Inactive
            //    updatePaymentSchedule["statuscode"] = new OptionSetValue(2);
            //}
            //else
            //{
            //    updatePaymentSchedule["vsd_nextrundate"] = nextRunDate;
            //}

            //updatePaymentSchedule["vsd_actualvalue"] = paymentAmounts.Item2;

            ////Added new logic//VS-4531.
            //if (paymentScheduleEntity.Contains("vsd_overpaymentemi") && paymentScheduleEntity["vsd_overpaymentemi"] != null && paymentScheduleEntity.Contains("vsd_overpaymentamount") && paymentScheduleEntity["vsd_overpaymentamount"] != null)
            //{
            //    var overPayment = ((Money)paymentScheduleEntity["vsd_overpaymentamount"]).Value;
            //    var emi = ((Money)paymentScheduleEntity["vsd_overpaymentemi"]).Value;

            //    if ((overPayment - emi) >= 0)
            //    {
            //        updatePaymentSchedule["vsd_remainingpaymentamount"] = overPayment - emi;
            //    }
            //    else if ((overPayment - emi) < 0)
            //    {
            //        updatePaymentSchedule["vsd_remainingpaymentamount"] = 0;
            //    }
            //}
            //OrgService.Update(updatePaymentSchedule);
        }
    }
}
