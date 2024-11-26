namespace Resources;

public class ProvinceRepository : BaseRepository<Vsd_Province, Province>, IProvinceRepository
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMapper _mapper;

    public ProvinceRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }

    public Province FirstOrDefault(FindProvinceQuery query)
    {
        var queryResults = BuildQueryable(query)
            .FirstOrDefault();
        return _mapper.Map<Province>(queryResults);
    }

    public IEnumerable<Province> Query(ProvinceQuery query)
    {
        var queryResults = BuildQueryable(query)
            .ToList();
        return _mapper.Map<IEnumerable<Province>>(queryResults);
    }

    private IQueryable<Vsd_Province> BuildQueryable(BaseProvinceQuery query) 
    {
        var queryable = _databaseContext.Vsd_ProvinceSet
            .WhereIf(query.Id != null, c => c.Id == query.Id);
        return queryable;
    }
}
