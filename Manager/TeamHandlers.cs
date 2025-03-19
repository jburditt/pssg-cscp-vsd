namespace Manager;

public class TeamHandlers(ITeamRepository repository, IMapper mapper) : FindQueryBaseHandlers<ITeamRepository, Team, FindTeamQuery, TeamQuery>(repository),
    IRequestHandler<FindTeamQuery, Team>,
    IRequestHandler<SingleTeamQuery, Team>
{
    public async Task<Team> Handle(SingleTeamQuery query, CancellationToken cancellationToken)
    {
        var entity = _repository.Single(query);
        var dto = mapper.Map<Team>(entity);
        return await Task.FromResult(dto);
    }
}
