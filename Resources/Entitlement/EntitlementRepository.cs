namespace Resources;

public class EntitlementRepository : BaseRepository<Vsd_Entitlement, Entitlement>, IEntitlementRepository
{
    private readonly DatabaseContext _databaseContext;

    public EntitlementRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
        _databaseContext = databaseContext;
    }

    // TODO this could be generalized to something like BaseRepository Update(id, Func<TEntity, object> properties)
    public bool UpdatePaymentScheduleStatus(Guid entitlementId, PaymentScheduleStatus status)
    {
        var entitlement = _databaseContext.Vsd_EntitlementSet.FirstOrDefault(x => x.Id == entitlementId);
        if (entitlement == null)
        {
            return false;
        }

        entitlement.Vsd_PaymentScheduleStatus = (Vsd_Entitlement_Vsd_PaymentScheduleStatus)status;
        _databaseContext.SaveChanges();
        return true;
    }
}
