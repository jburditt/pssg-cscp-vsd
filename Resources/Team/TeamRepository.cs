namespace Resources;

public class TeamRepository : BaseRepository<Database.Model.Team, Manager.Contract.Team>, ITeamRepository
{
    private readonly DatabaseContext _databaseContext;

    public TeamRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
        _databaseContext = databaseContext;
    }

    public Manager.Contract.Team Single(SingleTeamQuery query)
    {
        var entity = BuildQueryable(query)
            .Single();
        return _mapper.Map<Manager.Contract.Team>(entity);
    }

    public Manager.Contract.Team FirstOrDefault(FindTeamQuery query)
    {
        var entity = BuildQueryable(query)
            .FirstOrDefault();
        return _mapper.Map<Manager.Contract.Team>(entity);
    }

    public IEnumerable<Manager.Contract.Team> Query(TeamQuery query)
    {
        var entities = BuildQueryable(query)
            .ToList();
        return _mapper.Map<IEnumerable<Manager.Contract.Team>>(entities);
    }

    private IQueryable<Database.Model.Team> BuildQueryable(BaseTeamQuery query)
    {
        return _databaseContext.TeamSet
            .WhereIf(query.Name != null, x => x.Name == query.Name)
            .WhereIf(query.TeamType != null, x => x.TeamType == (Team_TeamType?)query.TeamType);
    }
}
