namespace Manager;

public class TeamHandlers(ITeamRepository repository) : FindQueryBaseHandlers<ITeamRepository, Team, FindTeamQuery, TeamQuery>(repository),
    IRequestHandler<FindTeamQuery, Team>
{

}
