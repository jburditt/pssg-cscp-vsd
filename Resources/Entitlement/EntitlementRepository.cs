namespace Resources;

public class EntitlementRepository : BaseRepository<Vsd_Entitlement, Entitlement>, IEntitlementRepository
{
    private readonly DatabaseContext _databaseContext;

    public EntitlementRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
        _databaseContext = databaseContext;
    }
}
