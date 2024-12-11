namespace Manager;

public class PaymentHandlers(IPaymentRepository repository) : QueryBaseHandlers<IPaymentRepository, Payment, PaymentQuery>(repository),
    IRequestHandler<PaymentQuery, IEnumerable<Payment>>,
    IRequestHandler<InsertCommand<Payment>, Guid>
{
    public async Task<bool> Handle(UpdatePaymentCasCommand command, CancellationToken cancellationToken)
    {
        var isSuccess = _repository.UpdatePaymentCas(command);
        return await Task.FromResult(isSuccess);
    }
}
