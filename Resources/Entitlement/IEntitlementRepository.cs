namespace Resources;

public interface IEntitlementRepository : IBaseRepository<Entitlement>
{
    bool UpdatePaymentScheduleStatus(Guid entitlementId, PaymentScheduleStatus status);
}
