namespace Resources;

public interface IPaymentRepository : IFindRepository<FindPaymentQuery, Payment>, IQueryRepository<PaymentQuery, Payment>, IBaseRepository<Payment>
{

}