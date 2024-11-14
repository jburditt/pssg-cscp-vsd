namespace Resources;

public class PaymentScheduleRepository : BaseRepository<Vsd_PaymentSchedule, PaymentSchedule>, IPaymentScheduleRepository
{
    private readonly DatabaseContext _databaseContext;
    private readonly IIncomeSupportParameterRepository _incomeSupportParameterRepository;

    public PaymentScheduleRepository(DatabaseContext databaseContext, IMapper mapper, IIncomeSupportParameterRepository incomeSupportParameterRepository) : base(databaseContext, mapper)
    {
        _databaseContext = databaseContext;
        _incomeSupportParameterRepository = incomeSupportParameterRepository;
    }

    public IEnumerable<PaymentScheduleResult> Query(PaymentScheduleEntitlementQuery query)
    {
        var queryResults = _databaseContext.Vsd_PaymentScheduleSet
            .Join(_databaseContext.Vsd_EntitlementSet, paymentSchedule => paymentSchedule.Vsd_EntitlementId.Id, entitlement => entitlement.Id, (paymentSchedule, entitlement) => new { PaymentSchedule = paymentSchedule, Entitlement = entitlement })
            .WhereIf(query.PaymentScheduleQuery?.StateCode != null, c => c.PaymentSchedule.StateCode == (Vsd_PaymentSchedule_StateCode)query.PaymentScheduleQuery.StateCode)
            .WhereIf(query.PaymentScheduleQuery?.BeforeStartDate != null, c => c.PaymentSchedule.Vsd_StartDate <= query.PaymentScheduleQuery.BeforeStartDate)
            .WhereIf(query.PaymentScheduleQuery?.BeforeNextRunDate != null, c => c.PaymentSchedule.Vsd_NextRUndate <= query.PaymentScheduleQuery.BeforeNextRunDate)
            .WhereIf(query.PaymentScheduleQuery?.NotNullCaseId != null, c => c.PaymentSchedule.Vsd_CaseId != null)
            .WhereIf(query.PaymentScheduleQuery?.NotNullPayeeId != null, c => c.PaymentSchedule.Vsd_Payee != null)
            .WhereIf(query.EntitlementQuery?.PaymentScheduleStatus != null, c => c.Entitlement.Vsd_PaymentScheduleStatus == (Vsd_Entitlement_Vsd_PaymentScheduleStatus)query.EntitlementQuery.PaymentScheduleStatus)
            .WhereIf(query.EntitlementQuery?.IsRecurring != null, c => c.Entitlement.Vsd_IsRecurring == query.EntitlementQuery.IsRecurring)
            .WhereIf(query.EntitlementQuery?.StatusCode != null, c => c.Entitlement.StatusCode == (Vsd_Entitlement_StatusCode)query.EntitlementQuery.StatusCode)
            .Select(x => new PaymentScheduleComposite(x.PaymentSchedule, x.Entitlement))
            .ToList();
        return _mapper.Map<IEnumerable<PaymentScheduleResult>>(queryResults);
    }

    public class PaymentScheduleComposite
    {
        public Vsd_PaymentSchedule PaymentSchedule { get; set; }
        public Vsd_Entitlement Entitlement { get; set; }

        public PaymentScheduleComposite(Vsd_PaymentSchedule paymentSchedule, Vsd_Entitlement entitlement)
        {
            PaymentSchedule = paymentSchedule;
            Entitlement = entitlement;
        }
    }

    public Tuple<Money, decimal> GetDollarAmounts(PaymentSchedule paymentSchedule, Entitlement entitlement, decimal minimumWage)
    {
        var amount = new Money(0);
        decimal actualAmount = 0;

        if (paymentSchedule.Frequency == null)
        {
            throw new Exception("Frequency is missing.");
        }
        if (paymentSchedule.XValue != null)
        {
            throw new Exception("Recurrence Value Within Frequency is missing.");
        }

        if (entitlement.BenefitTypeId != null)
        {
            throw new Exception("Benefit Type is missing.");
        }
        if (entitlement.SetCap != null)
        {
            throw new Exception("Set Cap is missing.");
        }

        //var benefitCategory = entitlement["vsd_benefitcategoryid"] as EntityReference;
        //var benefitType = entitlement["vsd_benefittypeid"] as EntityReference;
        var setCap = (decimal)entitlement.SetCap;

        if (entitlement.BenefitTypeId.Equals(new Guid("16127869-ec45-e911-a987-000d3af49373"))) //Child 1
        {
            minimumWage = (15 * minimumWage) / 100;
        }
        else if (entitlement.BenefitTypeId.Equals(new Guid("665326a4-0500-ea11-b812-00505683fbf4"))) //Child 2+
        {
            minimumWage = (10 * minimumWage) / 100;
        }
        else if (entitlement.BenefitTypeId.Equals(new Guid("6f54cf3b-8150-eb11-b822-00505683fbf4"))) //Financially Dependent IFM
        {
            if (entitlement.FinanciallyDependentIfmWage == null)
            {
                throw new Exception("Financially Dependent IFM Wage % is missing.");
            }

            minimumWage = ((decimal)entitlement.FinanciallyDependentIfmWage * minimumWage) / 100;
        }
        else if (entitlement.BenefitTypeId.Equals(new Guid("6c16896c-ec45-e911-a97d-000d3af49211"))) //Spouse
        {
            minimumWage = (75 * minimumWage) / 100;
        }

        if (entitlement.BenefitSubTypeId != null)
        {
            //var benefitSubType = entitlement["vsd_benefitsubtypeid"] as EntityReference;
            if (entitlement.BenefitSubTypeName != null && entitlement.BenefitSubTypeName.Equals("Minimum Wage", StringComparison.InvariantCultureIgnoreCase))
            {
                var result1 = (setCap * minimumWage * 52) / 12;

                if (paymentSchedule.PercentageDeduction != null)
                {
                    var deductionAmount = result1 * ((decimal)paymentSchedule.PercentageDeduction / 100);
                    result1 = result1 - deductionAmount;
                }

                actualAmount = result1;

                if (paymentSchedule.ShareOptions != null)
                {
                    if (paymentSchedule.ShareOptions == ShareOptions.AllocatedToCurrentSchedule_100000001) //% Share
                    {
                        if (paymentSchedule.ShareValue != null)
                        {
                            var shareValue = (decimal)paymentSchedule.ShareValue;
                            result1 = result1 * (shareValue / 100);
                        }
                        else
                            throw new Exception("Share Value is missing.");
                    }
                    else if (paymentSchedule.ShareOptions == ShareOptions.AllocatedToCurrentSchedule_100000002) //$ Share
                    {
                        if (paymentSchedule.ShareValue != null)
                        {
                            var shareValue = (decimal)paymentSchedule.ShareValue;
                            result1 = shareValue;
                        }
                        else
                            throw new Exception("Share Value is missing.");
                    }
                }

                if (paymentSchedule.CppDeduction != null)
                {
                    result1 = result1 - (decimal)paymentSchedule.CppDeduction;
                }

                if (paymentSchedule.OtherDeduction != null)
                {
                    result1 = result1 - (decimal)paymentSchedule.OtherDeduction;
                }

                if (paymentSchedule.OverPaymentEmi != null && paymentSchedule.OverPaymentAmount != null)
                {
                    var emi = (decimal)paymentSchedule.OverPaymentEmi;

                    if ((paymentSchedule.OverPaymentAmount - emi) >= 0)
                    {
                        result1 = result1 - emi;
                    }
                }

                if (paymentSchedule.Frequency == Frequency.Monthly) //Monthly
                {
                    var xValue = (int)paymentSchedule.XValue;
                    result1 = result1 * xValue;
                    actualAmount = actualAmount * xValue;
                }
                else if (paymentSchedule.Frequency == Frequency.Weekly) //Weekly
                {
                    result1 = ((result1 * 12) / 52);
                    actualAmount = ((actualAmount * 12) / 52);
                    var xValue = (int)paymentSchedule.XValue;
                    result1 = result1 * xValue;
                    actualAmount = actualAmount * xValue;
                }
                else if (paymentSchedule.Frequency == Frequency.Daily) //Daily
                {
                    result1 = ((result1 * 12) / 365);
                    actualAmount = ((actualAmount * 12) / 365);
                    var xValue = (int)paymentSchedule.XValue;
                    result1 = result1 * xValue;
                    actualAmount = actualAmount * xValue;
                }
                else if (paymentSchedule.Frequency == Frequency.Annually) //Annual
                {
                    result1 = result1 * 12;
                    actualAmount = actualAmount * 12;
                    var xValue = (int)paymentSchedule.XValue;
                    result1 = result1 * xValue;
                    actualAmount = actualAmount * xValue;
                }

                amount = new Money(result1);
            }
            else if (entitlement.BenefitSubTypeName.Equals("COLA", StringComparison.InvariantCultureIgnoreCase))
            {
                if (entitlement.EffectiveDate == DateTime.MinValue)
                {
                    throw new Exception("COLA Effective Date is missing.");
                }

                var result1 = _incomeSupportParameterRepository.GetCOLA(entitlement.EffectiveDate, setCap);

                if (paymentSchedule.PercentageDeduction != null)
                {
                    var deductionAmount = result1 * ((decimal)paymentSchedule.PercentageDeduction / 100);
                    result1 = result1 - deductionAmount;
                }

                actualAmount = result1;

                if (paymentSchedule.ShareOptions != null)
                {
                    if (paymentSchedule.ShareOptions == ShareOptions.AllocatedToCurrentSchedule_100000001) //% Share
                    {
                        if (paymentSchedule.ShareValue != null)
                        {
                            var shareValue = (decimal)paymentSchedule.ShareValue;
                            result1 = result1 * (shareValue / 100);
                        }
                        else
                            throw new Exception("Share Value is missing.");
                    }
                    else if (paymentSchedule.ShareOptions == ShareOptions.AllocatedToCurrentSchedule_100000002) //$ Share
                    {
                        if (paymentSchedule.ShareValue != null)
                        {
                            var shareValue = (decimal)paymentSchedule.ShareValue;
                            result1 = shareValue;
                        }
                        else
                            throw new Exception("Share Value is missing.");
                    }
                }

                if (paymentSchedule.CppDeduction != null)
                {
                    result1 = result1 - (decimal)paymentSchedule.CppDeduction;
                }

                if (paymentSchedule.OtherDeduction != null)
                {
                    result1 = result1 - (decimal)paymentSchedule.OtherDeduction;
                }

                if (paymentSchedule.OverPaymentEmi != null && paymentSchedule.OverPaymentAmount != null)
                {
                    var overPayment = (decimal)paymentSchedule.OverPaymentAmount;
                    var emi = (decimal)paymentSchedule.OverPaymentEmi;

                    if ((overPayment - emi) >= 0)
                    {
                        result1 = result1 - emi;
                    }
                }

                if (paymentSchedule.Frequency == Frequency.Monthly) //Monthly
                {
                    var xValue = (int)paymentSchedule.XValue;
                    result1 = result1 * xValue;
                    actualAmount = actualAmount * xValue;
                }
                else if (paymentSchedule.Frequency == Frequency.Weekly) //Weekly
                {
                    var xValue = (int)paymentSchedule.XValue;
                    result1 = result1 * xValue;
                    actualAmount = actualAmount * xValue;
                }
                else if (paymentSchedule.Frequency == Frequency.Daily) //Daily
                {
                    var xValue = (int)paymentSchedule.XValue;
                    result1 = result1 * xValue;
                    actualAmount = actualAmount * xValue;
                }
                else if (paymentSchedule.Frequency == Frequency.Annually) //Annual
                {
                    var xValue = (int)paymentSchedule.XValue;
                    result1 = result1 * xValue;
                    actualAmount = actualAmount * xValue;
                }

                amount = new Money(result1);
                //    }
                //    else
                //    {
                //        actualAmount = setCap;

                //        if (paymentSchedule.Contains("vsd_shareoptions") && paymentSchedule["vsd_shareoptions"] != null)
                //        {
                //            if (((OptionSetValue)paymentSchedule["vsd_shareoptions"]).Value == 100000001) //% Share
                //            {
                //                if (paymentSchedule.Contains("vsd_sharevalue") && paymentSchedule["vsd_sharevalue"] != null)
                //                {
                //                    var shareValue = (decimal)paymentSchedule["vsd_sharevalue"];

                //                    amount = new Money(setCap * (shareValue / 100));
                //                }
                //                else
                //                    throw new InvalidPluginExecutionException("Share Value is empty..");
                //            }
                //            else if (((OptionSetValue)paymentSchedule["vsd_shareoptions"]).Value == 100000002) //$ Share
                //            {
                //                if (paymentSchedule.Contains("vsd_sharevalue") && paymentSchedule["vsd_sharevalue"] != null)
                //                {
                //                    var shareValue = (decimal)paymentSchedule["vsd_sharevalue"];

                //                    amount = new Money(shareValue);
                //                }
                //                else
                //                    throw new InvalidPluginExecutionException("Share Value is empty..");
                //            }
                //            else
                //                amount = new Money(setCap);
                //        }
                //        else
                //            amount = new Money(setCap);
                //    }
            }
        //else
        //{
        //    actualAmount = setCap;

        //    if (paymentSchedule.Contains("vsd_shareoptions") && paymentSchedule["vsd_shareoptions"] != null)
        //    {
        //        if (((OptionSetValue)paymentSchedule["vsd_shareoptions"]).Value == 100000001) //% Share
        //        {
        //            if (paymentSchedule.Contains("vsd_sharevalue") && paymentSchedule["vsd_sharevalue"] != null)
        //            {
        //                var shareValue = (decimal)paymentSchedule["vsd_sharevalue"];

        //                amount = new Money(setCap * (shareValue / 100));
        //            }
        //            else
        //                throw new InvalidPluginExecutionException("Share Value is empty..");
        //        }
        //        else if (((OptionSetValue)paymentSchedule["vsd_shareoptions"]).Value == 100000002) //$ Share
        //        {
        //            if (paymentSchedule.Contains("vsd_sharevalue") && paymentSchedule["vsd_sharevalue"] != null)
        //            {
        //                var shareValue = (decimal)paymentSchedule["vsd_sharevalue"];

        //                amount = new Money(shareValue);
        //            }
        //            else
        //                throw new InvalidPluginExecutionException("Share Value is empty..");
        //        }
        //        else
        //            amount = new Money(setCap);
        //    }
        //    else
        //        amount = new Money(setCap);
        }

        return new Tuple<Money, decimal>(amount, actualAmount);
    }
}
