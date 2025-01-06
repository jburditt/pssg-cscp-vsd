namespace Resources;

public class ConfigurationRepository : BaseRepository<Vsd_Config, Configuration>, IConfigurationRepository
{
    private readonly DatabaseContext _databaseContext;

    public ConfigurationRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
        _databaseContext = databaseContext;
    }

    public IEnumerable<Configuration> Query(ConfigurationQuery query)
    {
        var queryResults = _databaseContext.Vsd_ConfigSet
            .WhereIf(query.StateCode != null, c => c.StateCode == (Vsd_Config_StateCode?)query.StateCode)
            .WhereIf(query.Group != null, c => c.Vsd_Group == query.Group)
            .WhereIf(query.Key != null, c => c.Vsd_Key == query.Key)
            .WhereIf(query.ProgramUnit != null, c => c.Vsd_ProgramUnit == (Vsd_ProgramUnit?)query.ProgramUnit)
            .ToList();
        return _mapper.Map<IEnumerable<Configuration>>(queryResults);
    }
}

