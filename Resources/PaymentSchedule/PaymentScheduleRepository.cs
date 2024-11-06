namespace Resources;

public class PaymentScheduleRepository : BaseRepository<Vsd_PaymentSchedule, PaymentSchedule>, IPaymentScheduleRepository
{
    private readonly DatabaseContext _databaseContext;

    public PaymentScheduleRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
        _databaseContext = databaseContext;
    }

    public IEnumerable<PaymentScheduleResult> Query(PaymentScheduleQuery paymentScheduleQuery)
    {
        var queryResults =
            (from paymentSchedule in _databaseContext.Vsd_PaymentScheduleSet
             join entitlement in _databaseContext.Vsd_EntitlementSet on paymentSchedule.Vsd_EntitlementId.Id equals entitlement.Id
             select new PaymentScheduleComposite(paymentSchedule, entitlement))
            .WhereIf(paymentScheduleQuery.StateCode != null, c => c.PaymentSchedule.StateCode == (Vsd_PaymentSchedule_StateCode)paymentScheduleQuery.StateCode)
            .WhereIf(paymentScheduleQuery.BeforeStartDate != null, c => c.PaymentSchedule.Vsd_StartDate <= paymentScheduleQuery.BeforeStartDate)
            .WhereIf(paymentScheduleQuery.BeforeNextRunDate != null, c => c.PaymentSchedule.Vsd_NextRUndate <= paymentScheduleQuery.BeforeNextRunDate)
            .WhereIf(paymentScheduleQuery.NotNullCaseId != null, c => c.PaymentSchedule.Vsd_CaseId != null)
            .WhereIf(paymentScheduleQuery.NotNullPayeeId != null, c => c.PaymentSchedule.Vsd_Payee != null);

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
}
