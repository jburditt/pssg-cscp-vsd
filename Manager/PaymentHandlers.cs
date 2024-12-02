namespace Manager;

public class PaymentHandlers(IPaymentRepository repository) : QueryBaseHandlers<IPaymentRepository, Payment, PaymentQuery>(repository),
    IRequestHandler<PaymentQuery, IEnumerable<Payment>>,
    IRequestHandler<InsertCommand<Payment>, Guid>
{

}
