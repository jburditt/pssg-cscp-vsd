﻿namespace Manager;

public class PaymentScheduleHandlers : BaseHandlers<IPaymentScheduleRepository, PaymentSchedule>,
    IRequestHandler<PaymentScheduleEntitlementQuery, IEnumerable<PaymentScheduleEntitlement>>,
    IRequestHandler<GetPaymentTotalCommand, PaymentTotalResult>,
    IRequestHandler<GetNextRuntimeCommand, DateTime>,
    IRequestHandler<UpdateCommand<PaymentSchedule>, bool>,
    IRequestHandler<ScheduleCvapPaymentsCommand, bool>
{
    private readonly IPaymentScheduleService _service;
    private readonly IMapper _mapper;

    public PaymentScheduleHandlers(IPaymentScheduleRepository repository, IPaymentScheduleService service, IMapper mapper) : base(repository)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PaymentScheduleEntitlement>> Handle(PaymentScheduleEntitlementQuery query, CancellationToken cancellationToken)
    {
        var entities = _repository.Query(query);
        var dtos = _mapper.Map<IEnumerable<PaymentScheduleEntitlement>>(entities);
        return await Task.FromResult(dtos);
    }

    public async Task<PaymentTotalResult> Handle(GetPaymentTotalCommand command, CancellationToken cancellationToken)
    {
        var paymentTotal = _service.GetPaymentTotal(command.PaymentSchedule, command.Entitlement, command.MinimumWage);
        return await Task.FromResult(paymentTotal);
    }

    public async Task<DateTime> Handle(GetNextRuntimeCommand command, CancellationToken cancellationToken)
    {
        var nextPaymentDate = _service.GetNextRuntime(command.PaymentSchedule);
        return await Task.FromResult(nextPaymentDate);
    }

    public async Task<bool> Handle(ScheduleCvapPaymentsCommand command, CancellationToken cancellationToken)
    {
        return await _service.ScheduleCvapPayments();
    }
}
