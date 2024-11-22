namespace Manager;

public class PaymentScheduleHandlers : BaseHandlers<IPaymentScheduleRepository, PaymentSchedule>,
    IRequestHandler<PaymentScheduleEntitlementQuery, IEnumerable<PaymentScheduleEntitlement>>
{
    private readonly IMapper _mapper;

    public PaymentScheduleHandlers(IPaymentScheduleRepository repository, IMapper mapper) : base(repository)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<PaymentScheduleEntitlement>> Handle(PaymentScheduleEntitlementQuery query, CancellationToken cancellationToken)
    {
        var entities = _repository.Query(query);
        var dtos = _mapper.Map<IEnumerable<PaymentScheduleEntitlement>>(entities);
        return await Task.FromResult(dtos);
    }
}
