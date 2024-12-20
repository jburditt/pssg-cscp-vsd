namespace Resources;

public interface IPaymentScheduleRepository : IQueryRepository<PaymentScheduleEntitlementQuery, PaymentScheduleEntitlement>, IBaseRepository<PaymentSchedule>
{
    PaymentSchedule FirstOrDefault(PaymentScheduleQuery query);
}