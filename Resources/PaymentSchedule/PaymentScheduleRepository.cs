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

    public PaymentSchedule FirstOrDefault(PaymentScheduleQuery query)
    {
        var queryResults = _databaseContext.Vsd_PaymentScheduleSet
            .WhereIf(query.Id != null, c => c.Id == query.Id)
            .WhereIf(query.StateCode != null, c => c.StateCode == (Vsd_PaymentSchedule_StateCode)query.StateCode)
            .WhereIf(query.BeforeStartDate != null, c => c.Vsd_StartDate <= query.BeforeStartDate)
            .WhereIf(query.BeforeNextRunDate != null, c => c.Vsd_NextRUndate <= query.BeforeNextRunDate)
            .WhereIf(query.NotNullCaseId, c => c.Vsd_CaseId != null)
            .WhereIf(query.NotNullPayeeId, c => c.Vsd_Payee != null)
            .FirstOrDefault();
        return _mapper.Map<PaymentSchedule>(queryResults);
    }

    // TODO rewrite this so that entitlement is an object that is attached to payment schedule
    public IEnumerable<PaymentScheduleEntitlement> Query(PaymentScheduleEntitlementQuery query)
    {
        ArgumentNullException.ThrowIfNull(query?.PaymentScheduleQuery);

        //var paymentSchedule = _databaseContext.Vsd_PaymentScheduleSet.Where(x => x.Id == new Guid("a7ec69fb-dc9f-ec11-b831-00505683fbf4")).Single();
        //var entity = _databaseContext.Vsd_EntitlementSet.Where(x => x.Id == paymentSchedule.Vsd_EntitlementId.Id).Single();
        //var result = new PaymentScheduleComposite(paymentSchedule, entity);
        //var mappedResult = _mapper.Map<PaymentScheduleEntitlement>(result);
        //return new List<PaymentScheduleEntitlement> { mappedResult };

        var queryResults = _databaseContext.Vsd_PaymentScheduleSet
            .Join(_databaseContext.Vsd_EntitlementSet, paymentSchedule => paymentSchedule.Vsd_EntitlementId.Id, entitlement => entitlement.Id, (paymentSchedule, entitlement) => new { PaymentSchedule = paymentSchedule, Entitlement = entitlement })
            .WhereIf(query.PaymentScheduleQuery.StateCode != null, c => c.PaymentSchedule.StateCode == (Vsd_PaymentSchedule_StateCode)query.PaymentScheduleQuery.StateCode)
            .WhereIf(query.PaymentScheduleQuery.BeforeStartDate != null, c => c.PaymentSchedule.Vsd_StartDate <= query.PaymentScheduleQuery.BeforeStartDate)
            .WhereIf(query.PaymentScheduleQuery.BeforeNextRunDate != null, c => c.PaymentSchedule.Vsd_NextRUndate <= query.PaymentScheduleQuery.BeforeNextRunDate)
            .WhereIf(query.PaymentScheduleQuery.NotNullCaseId, c => c.PaymentSchedule.Vsd_CaseId != null)
            .WhereIf(query.PaymentScheduleQuery.NotNullPayeeId, c => c.PaymentSchedule.Vsd_Payee != null)
            .WhereIf(query.EntitlementQuery?.PaymentScheduleStatus != null, c => c.Entitlement.Vsd_PaymentScheduleStatus == (Vsd_Entitlement_Vsd_PaymentScheduleStatus)query.EntitlementQuery.PaymentScheduleStatus)
            .WhereIf(query.EntitlementQuery?.IsRecurring != null, c => c.Entitlement.Vsd_IsRecurring == query.EntitlementQuery.IsRecurring)
            .WhereIf(query.EntitlementQuery?.StatusCode != null, c => c.Entitlement.StatusCode == (Vsd_Entitlement_StatusCode)query.EntitlementQuery.StatusCode)
            .Select(x => new PaymentScheduleComposite(x.PaymentSchedule, x.Entitlement))
            .ToList();
        return _mapper.Map<IEnumerable<PaymentScheduleEntitlement>>(queryResults);
    }

    public record PaymentScheduleComposite(Vsd_PaymentSchedule paymentSchedule, Vsd_Entitlement entitlement);
}
