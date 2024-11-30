namespace Utilities;

// TODO should this file be moved to Resources project?
// TODO replace Money with decimal
public interface IPaymentScheduleService
{
    PaymentTotalResult GetPaymentTotal(PaymentSchedule paymentSchedule, Entitlement entitlement, decimal minimumWage);
    Tuple<Money, decimal> GetDollarAmounts(PaymentSchedule paymentSchedule, Entitlement entitlement, decimal minimumWage);
    DateTime GetNextRuntime(PaymentSchedule paymentSchedule);
}

public record PaymentTotalResult(decimal Amount, decimal ActualAmount);

public class PaymentScheduleService(IPaymentScheduleRepository paymentScheduleRepository, IIncomeSupportParameterRepository incomeSupportParameterRepository, IProvinceRepository provinceRepository) 
    : IPaymentScheduleService
{
    public PaymentTotalResult GetPaymentTotal(PaymentSchedule paymentSchedule, Entitlement entitlement, decimal minimumWage)
    {
        Money amount = new Money();
        Money actualAmount = new Money();

        if (paymentSchedule.PrimaryScheduleId != null)
        {
            var primaryScheduleQuery = new PaymentScheduleQuery { Id = paymentSchedule.PrimaryScheduleId };
            var primarySchedule = paymentScheduleRepository.FirstOrDefault(primaryScheduleQuery);

            var primaryAmounts = GetDollarAmounts(primarySchedule, entitlement, minimumWage);

            if (paymentSchedule.ShareOptions != null)
            {
                if (paymentSchedule.ShareOptions == ShareOptions.AllocatedToCurrentSchedule_100000001) //% Share
                {
                    if (paymentSchedule.ShareValue != null)
                    {
                        var shareValue = (decimal)paymentSchedule.ShareValue;
                        amount = new Money(primaryAmounts.Item2 * (shareValue / 100));
                        actualAmount = new Money(amount.Value);

                        var primaryFrequency = primarySchedule.Frequency;
                        var childFrequency = primarySchedule.Frequency;

                        var primaryXValue = (int)primarySchedule.XValue;
                        var childXValue = (int)paymentSchedule.XValue;

                        amount = new Money(amount.Value / primaryXValue);
                        actualAmount = new Money(actualAmount.Value / primaryXValue);

                        if (primaryFrequency == Frequency.Annually) //Annual
                        {
                            amount = new Money((amount.Value / 12) * childXValue);
                            actualAmount = new Money((actualAmount.Value / 12) * childXValue);
                        }
                        else if (primaryFrequency == Frequency.Monthly) //Monthly
                        {
                            amount = new Money(amount.Value * childXValue);
                            actualAmount = new Money(actualAmount.Value * childXValue);
                        }
                        else if (primaryFrequency == Frequency.Weekly) //Weekly
                        {
                            amount = new Money(((amount.Value * 52) / 12) * childXValue);
                            actualAmount = new Money(((actualAmount.Value * 52) / 12) * childXValue);
                        }
                        else if (primaryFrequency == Frequency.Daily) //Daily
                        {
                            amount = new Money(((amount.Value * 365) / 12) * childXValue);
                            actualAmount = new Money(((actualAmount.Value * 365) / 12) * childXValue);
                        }
                    }
                    else
                        throw new Exception("Share Value is missing.");
                }
                else if (paymentSchedule.ShareOptions == ShareOptions.AllocatedToCurrentSchedule_100000002) //$ Share
                {
                    if (paymentSchedule.ShareValue != null)
                    {
                        actualAmount = new Money((decimal)paymentSchedule.ShareValue);
                        amount = actualAmount;
                    }
                    else
                        throw new InvalidPluginExecutionException("Share Value is empty..");
                }
            }
        }
        else
        {
            var amounts = GetDollarAmounts(paymentSchedule, entitlement, minimumWage);
            amount = amounts.Item1;
            actualAmount = new Money(amounts.Item2);
        }

        if (!(entitlement.TaxExemptFlag ?? false)) //GST
        {
            var bcProvinceQuery = new FindProvinceQuery();
            bcProvinceQuery.Id = Constant.ProvinceBc;
            var bcProvince = provinceRepository.FirstOrDefault(bcProvinceQuery);
            ArgumentNullException.ThrowIfNull(bcProvince.TaxRate);

            amount = new Money(amount.Value + (amount.Value * (decimal)bcProvince.TaxRate));
            actualAmount = new Money(actualAmount.Value + (actualAmount.Value * (decimal)bcProvince.TaxRate));
        }

        return new PaymentTotalResult(amount.Value, actualAmount.Value);
    }

    public Tuple<Money, decimal> GetDollarAmounts(PaymentSchedule paymentSchedule, Entitlement entitlement, decimal minimumWage)
    {
        var amount = new Money(0);
        decimal actualAmount = 0;

        if (paymentSchedule.Frequency == null)
        {
            throw new Exception("Frequency is missing.");
        }
        if (paymentSchedule.XValue == null)
        {
            throw new Exception("Recurrence Value Within Frequency is missing.");
        }

        if (entitlement.BenefitTypeId == null)
        {
            throw new Exception("Benefit Type is missing.");
        }
        if (entitlement.SetCap == null)
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
            else if (entitlement.BenefitSubTypeName != null && entitlement.BenefitSubTypeName.Equals("COLA", StringComparison.InvariantCultureIgnoreCase))
            {
                if (entitlement.EffectiveDate == DateTime.MinValue)
                {
                    throw new Exception("COLA Effective Date is missing.");
                }

                var result1 = incomeSupportParameterRepository.GetCOLA(entitlement.EffectiveDate, setCap);

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
            }
            else
            {
                actualAmount = setCap;

                if (paymentSchedule.ShareOptions != null)
                {
                    if (paymentSchedule.ShareOptions == ShareOptions.AllocatedToCurrentSchedule_100000001) //% Share
                    {
                        if (paymentSchedule.ShareValue != null)
                        {
                            var shareValue = (decimal)paymentSchedule.ShareValue;

                            amount = new Money(setCap * (shareValue / 100));
                        }
                        else
                            throw new Exception("Share Value is missing.");
                    }
                    else if (paymentSchedule.ShareOptions == ShareOptions.AllocatedToCurrentSchedule_100000002) //$ Share
                    {
                        if (paymentSchedule.ShareValue != null)
                        {
                            var shareValue = (decimal)paymentSchedule.ShareValue;

                            amount = new Money(shareValue);
                        }
                        else
                            throw new Exception("Share Value is missing.");
                    }
                    else
                        amount = new Money(setCap);
                }
                else
                    amount = new Money(setCap);
            }
        }
        else
        {
            actualAmount = setCap;

            if (paymentSchedule.ShareOptions != null)
            {
                if (paymentSchedule.ShareOptions == ShareOptions.AllocatedToCurrentSchedule_100000001) //% Share
                {
                    if (paymentSchedule.ShareValue != null)
                    {
                        var shareValue = (decimal)paymentSchedule.ShareValue;

                        amount = new Money(setCap * (shareValue / 100));
                    }
                    else
                        throw new Exception("Share Value is missing.");
                }
                else if (paymentSchedule.ShareOptions == ShareOptions.AllocatedToCurrentSchedule_100000002) //$ Share
                {
                    if (paymentSchedule.ShareValue != null)
                    {
                        var shareValue = (decimal)paymentSchedule.ShareValue;

                        amount = new Money(shareValue);
                    }
                    else
                        throw new Exception("Share Value is missing.");
                }
                else
                    amount = new Money(setCap);
            }
            else
                amount = new Money(setCap);
        }

        return new Tuple<Money, decimal>(amount, actualAmount);
    }

    public DateTime GetNextRuntime(PaymentSchedule paymentSchedule)
    {
        var result = ((DateTime)paymentSchedule.NextRunDate).ToLocalTime();
        if (paymentSchedule.FirstRunDate != null)
            result = ((DateTime)paymentSchedule.FirstRunDate).ToLocalTime();

        if (paymentSchedule.Frequency == Frequency.Weekly) //Weekly
        {
            do
            {
                var xValue = (int)paymentSchedule.XValue;
                result = result.AddDays(7 * xValue);
            } while (result < DateTime.Now);

            if (result.Day == DateTime.Now.Day && result.Month == DateTime.Now.Month && result.Year == DateTime.Now.Year)
            {
                var xValue = (int)paymentSchedule.XValue;
                result = result.AddDays(7 * xValue);
            }
        }
        else if (paymentSchedule.Frequency == Frequency.Daily) //Daily
        {
            do
            {
                var xValue = (int)paymentSchedule.XValue;
                result = result.AddDays(xValue);
            } while (result < DateTime.Now);

            if (result.Day == DateTime.Now.Day && result.Month == DateTime.Now.Month && result.Year == DateTime.Now.Year)
            {
                var xValue = (int)paymentSchedule.XValue;
                result = result.AddDays(xValue);
            }
        }
        else if (paymentSchedule.Frequency == Frequency.Annually) //Annually
        {
            do
            {
                var xValue = (int)paymentSchedule.XValue;
                result = result.AddYears(xValue);
            } while (result < DateTime.Now);

            if (result.Year == DateTime.Now.Year)
            {
                var xValue = (int)paymentSchedule.XValue;
                result = result.AddYears(xValue);
            }
        }
        else //Monthly
        {
            do
            {
                var xValue = (int)paymentSchedule.XValue;
                result = result.AddMonths(xValue);
            } while (result < DateTime.Now);

            if (result.Month == DateTime.Now.Month)
            {
                var xValue = (int)paymentSchedule.XValue;
                result = result.AddMonths(xValue);
            }

            if ((result.Month == 2 || result.Month == 12) && result.Day >= 20) //Short Months and date to the end of the month VS-2170
            {
                //result = result.AddDays(15 - result.Day);
                result = new DateTime(result.Year, result.Month, 15);
            }
        }

        if (result.DayOfWeek == DayOfWeek.Saturday)
            result = result.AddDays(-1);
        else if (result.DayOfWeek == DayOfWeek.Sunday)
            result = result.AddDays(-2);
        return result;
    }
}
