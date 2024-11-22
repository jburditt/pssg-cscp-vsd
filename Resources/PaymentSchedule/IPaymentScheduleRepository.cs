namespace Resources;

public interface IPaymentScheduleRepository : IQueryRepository<PaymentScheduleEntitlementQuery, PaymentScheduleEntitlement>, IBaseRepository<PaymentSchedule>
{
    Tuple<Money, decimal> GetDollarAmounts(PaymentSchedule paymentSchedule, Entitlement entitlement, decimal minimumWage);
    DateTime GetNextRuntime(PaymentSchedule paymentSchedule);
}