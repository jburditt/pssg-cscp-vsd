namespace Resources;

public interface IPaymentScheduleRepository : IQueryRepository<PaymentScheduleEntitlementQuery, PaymentScheduleResult>, IBaseRepository<PaymentSchedule>
{

}