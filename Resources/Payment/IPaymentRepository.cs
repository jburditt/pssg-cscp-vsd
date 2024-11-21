namespace Resources;

public interface IPaymentRepository : IQueryRepository<PaymentQuery, Payment>, IBaseRepository<Payment>
{

}