namespace Resources;

public class CountryRepository : ICountryRepository
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMapper _mapper;

    public CountryRepository(DatabaseContext databaseContext, IMapper mapper)
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }

    public Country FirstOrDefault(FindCountryQuery query)
    {
        var entity = _databaseContext.Vsd_CountrySet
            .Where(query)
            .FirstOrDefault();
        return _mapper.Map<Country>(entity);
    }

    public Country Single(SingleCountryQuery query)
    {
        var entity = _databaseContext.Vsd_CountrySet
            .Where(query)
            .Single();
        return _mapper.Map<Country>(entity);
    }
}

public static class CountryExtensions
{
    public static IQueryable<Vsd_Country> Where(this IQueryable<Vsd_Country> query, BaseCountryQuery CountryQuery)
    {
        return query
            .WhereIf(CountryQuery.Id != null, c => c.Id == CountryQuery.Id)
            .WhereIf(CountryQuery.StateCode != null, c => c.StateCode == (Vsd_Country_StateCode?)CountryQuery.StateCode)
            .WhereIf(CountryQuery.Name != null, c => c.Vsd_Name == CountryQuery.Name)
            .WhereIf(CountryQuery.NotNullCode, c => c.Vsd_Code != null);
    }
}
