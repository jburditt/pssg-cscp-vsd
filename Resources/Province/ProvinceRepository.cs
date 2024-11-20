namespace Resources;

public class ProvinceRepository : IProvinceRepository
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMapper _mapper;

    public ProvinceRepository(DatabaseContext databaseContext, IMapper mapper) //: base(databaseContext, mapper)
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }

    public Province FirstOrDefault(ProvinceQuery query)
    {
        var queryResults = _databaseContext.Vsd_ProvinceSet
            .WhereIf(query.Id != null, c => c.Id == query.Id)
            .FirstOrDefault();
        return _mapper.Map<Province>(queryResults);
    }
}
