namespace Manager;

public class PaymentHandlers(IPaymentRepository repository, IPaymentService service) : QueryBaseHandlers<IPaymentRepository, Payment, PaymentQuery>(repository),
    IRequestHandler<PaymentQuery, IEnumerable<Payment>>,
    IRequestHandler<InsertCommand<Payment>, Guid>,
    IRequestHandler<SendPaymentsToCasCommand, bool>
{
    public async Task<bool> Handle(UpdatePaymentCasCommand command, CancellationToken cancellationToken)
    {
        var isSuccess = _repository.UpdatePaymentCas(command);
        return await Task.FromResult(isSuccess);
    }

    public async Task<bool> Handle(SendPaymentsToCasCommand dummy, CancellationToken cancellationToken)
    {
        var isSuccess = await service.SendPaymentsToCas();
        return await Task.FromResult(isSuccess);
    }
}
