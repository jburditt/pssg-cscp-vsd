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
        var queryResults2 = (
             from paymentSchedule in _databaseContext.Vsd_PaymentScheduleSet
             join entitlement in _databaseContext.Vsd_EntitlementSet on paymentSchedule.Vsd_EntitlementId.Id equals entitlement.Id
             select new PaymentScheduleComposite(paymentSchedule, entitlement))
            .WhereIf(paymentScheduleQuery.StateCode != null, c => c.PaymentSchedule.StateCode == (Vsd_PaymentSchedule_StateCode)paymentScheduleQuery.StateCode)
            .WhereIf(paymentScheduleQuery.BeforeStartDate != null, c => c.PaymentSchedule.Vsd_StartDate <= paymentScheduleQuery.BeforeStartDate)
            .WhereIf(paymentScheduleQuery.BeforeNextRunDate != null, c => c.PaymentSchedule.Vsd_NextRUndate <= paymentScheduleQuery.BeforeNextRunDate)
            .WhereIf(paymentScheduleQuery.NotNullCaseId != null, c => c.PaymentSchedule.Vsd_CaseId != null)
             select new { PaymentSchedule = paymentSchedule, Entitlement = entitlement });
        var queryResults = queryResults2.Where(c => c.paymentSchedule.StateCode == (Vsd_PaymentSchedule_StateCode)paymentScheduleQuery.StateCode);
        var test = queryResults2.ToList();
        var queryResults = queryResults2.Where(c => c.PaymentSchedule.StateCode == (Vsd_PaymentSchedule_StateCode)paymentScheduleQuery.StateCode);
        var test2 = queryResults.Select(x => new PaymentScheduleComposite(x.PaymentSchedule, x.Entitlement)).ToList();

        return _mapper.Map<IEnumerable<PaymentScheduleResult>>(test2);
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
