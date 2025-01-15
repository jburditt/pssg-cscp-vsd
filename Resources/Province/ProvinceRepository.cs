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
        var entity = BuildQueryable(query)
            .FirstOrDefault();
        return _mapper.Map<Province>(entity);
    }

    public Province Single(FindProvinceQuery query)
    {
        var entity = BuildQueryable(query)
            .Single();
        return _mapper.Map<Province>(entity);
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
            .WhereIf(query.Id != null, c => c.Id == query.Id)
            .WhereIf(query.Name != null, c => c.Vsd_Name == query.Name)
            .WhereIf(query.CountryId != null, c => c.Vsd_CountryId.Id == query.CountryId)
            .WhereIf(query.StateCode != null, c => c.StateCode == (Vsd_Province_StateCode?)query.StateCode)
            .WhereIf(query.NotNullCode, c => c.Vsd_Code != null);
        return queryable;
    }
}
