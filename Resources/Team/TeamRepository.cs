namespace Resources;

public class TeamRepository : BaseRepository<Database.Model.Team, Manager.Contract.Team>, ITeamRepository
{
    private readonly DatabaseContext _databaseContext;

    public TeamRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
        _databaseContext = databaseContext;
    }

    public Manager.Contract.Team FirstOrDefault(TeamQuery query)
    {
        var entity = BuildQueryable(query)
            .FirstOrDefault();
        return _mapper.Map<Manager.Contract.Team>(entity);
    }

    private IQueryable<Database.Model.Team> BuildQueryable(TeamQuery query)
    {
        return _databaseContext.TeamSet
            .WhereIf(query.Name != null, x => x.Name == query.Name)
            .WhereIf(query.TeamType != null, x => x.TeamType == (Team_TeamType)query.TeamType);
    }
}
