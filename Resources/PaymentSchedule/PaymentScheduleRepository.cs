using Database.Model;

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
        var queryResults = _databaseContext.Vsd_PaymentScheduleSet
            .Join(_databaseContext.Vsd_EntitlementSet, paymentSchedule => paymentSchedule.Vsd_EntitlementId.Id, entitlement => entitlement.Id, (paymentSchedule, entitlement) => new { PaymentSchedule = paymentSchedule, Entitlement = entitlement })
            .WhereIf(paymentScheduleQuery.StateCode != null, c => c.PaymentSchedule.StateCode == (Vsd_PaymentSchedule_StateCode)paymentScheduleQuery.StateCode)
            .WhereIf(paymentScheduleQuery.BeforeStartDate != null, c => c.PaymentSchedule.Vsd_StartDate <= paymentScheduleQuery.BeforeStartDate)
            .WhereIf(paymentScheduleQuery.BeforeNextRunDate != null, c => c.PaymentSchedule.Vsd_NextRUndate <= paymentScheduleQuery.BeforeNextRunDate)
            .WhereIf(paymentScheduleQuery.NotNullCaseId != null, c => c.PaymentSchedule.Vsd_CaseId != null)
            .WhereIf(paymentScheduleQuery.NotNullPayeeId != null, c => c.PaymentSchedule.Vsd_Payee != null)
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
}
