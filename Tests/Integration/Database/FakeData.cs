public static partial class FakeData
{
    public static List<Contract> Contracts = new List<Contract>
    {
        new Contract
        {
            Id = new Guid("ce4f37e8-7043-41b2-a0e7-23fb93fa53c9"),
            StateCode = StateCode.Active,
            StatusCode = ContractStatusCode.DulyExecuted,
            MethodOfPayment = MethodOfPayment.Cheque,
            ContractType = ContractType.TuaVictimServicesVawp,
            //ProgramId = new Guid("05dcfc76-77d1-471f-9b7a-a79332186fac"),
        },
    };

    public static List<InvoiceLineDetail> InvoiceLineDetails = new List<InvoiceLineDetail>
    {
        new InvoiceLineDetail
        {
            Id = new Guid("00000000-e81b-ec11-b82d-00505683fbf4"),
            // NOTE this is an id that exists on DEV, change this if you need reliable test data
            InvoiceId = new Guid("520fd904-b48e-ec11-b82c-005056830319"),
            Owner = new DynamicReference(new Guid("46fd16c0-fc6e-ea11-b818-00505683fbf4"), Database.Model.Account.EntityLogicalName),
            InvoiceType = InvoiceType.OtherPayments,
            ProgramUnit = ProgramUnit.Cpu,
            Approved = YesNo.Yes,
            AmountSimple = 100.00m,
            ProvinceStateId = new Guid("FDE4DBCA-989A-E811-8155-480FCFF4F6A1"),
            TaxExemption = TaxExemption.NoTax,
        }
    };

    public static List<PaymentSchedule> PaymentSchedules = new List<PaymentSchedule>
    {
        new PaymentSchedule
        {
            Id = new Guid("c9defbda-2630-ef11-b850-00505683fbf4"),
            StateCode = StateCode.Active,
            StatusCode = PaymentScheduleStatusCode.Active,
            FirstRunDate = new DateTime(2024, 6, 30, 7, 0, 0),
            NextRunDate = new DateTime(2024, 6, 30, 7, 0, 0),
            StartDate = new DateTime(2024, 6, 30, 7, 0, 0),
            Frequency = Frequency.Monthly,
            XValue = 22,
            PercentageDeduction = null,
            ShareOptions = ShareOptions.NoShare,
            ShareValue = null,
            CppDeduction = null,
            OtherDeduction = null,
            OverPaymentEmi = null,
            OverPaymentAmount = null,
            EndDate = null,
            TotalAmountOfIncomeSupport = 89.0000m,
            ActualValue = null,
            RemainingPaymentAmount = null,
            //EntitlementId = new Guid("e426deb4-97d3-eb11-b821-005056830319"),
            CaseId = new Guid("7ed8816c-72d0-eb11-b821-005056830319"),
            CaseName = "21-03220-VIC-Durant, Kevin",
            Payee = new DynamicReference(new Guid("eab0de80-fcd8-eb11-b828-00505683fbf4"), "contact"),
            PrimaryScheduleId = null,
            Entitlements = new List<Entitlement>
            {
                new Entitlement
                {
                    Id = new Guid("26df878f-b0bb-408b-b829-427053fcd0f0"),
                    StateCode = StateCode.Active,
                    StatusCode = EntitlementStatusCode.Approved,
                    EntitlementStage = EntitlementStage.ReadyForCc,
                    EffectiveDate = new DateTime(2024, 6, 30, 7, 0, 0),
                    SetCap = 48.0000000000m,
                    TaxExemptFlag = false,
                    FinanciallyDependentIfmWage = null,
                    CvapAvailableEntitilement = 44.00m,
                    PaymentScheduleStatus = PaymentScheduleStatus.Active,
                    IsRecurring = true,
                    //BenefitCategoryId = new Guid("e9369555-ec45-e911-a982-000d3af49637"),
                    BenefitCategoryId = new Guid("b3e31857-ec45-e911-a97c-000d3af490cc"),
                    BenefitTypeId = new Guid("ea369555-ec45-e911-a982-000d3af49637"),
                    BenefitSubTypeId = new Guid("0ccd5f4f-f02f-ef11-b850-00505683fbf4"),
                    BenefitSubTypeName = string.Empty,
                    Case = new StaticReference(new Guid("7ed8816c-72d0-eb11-b821-005056830319"), "incident"),
                    ApplicantType = ApplicantType.Victim,
                }
            }
        }
    };
}
