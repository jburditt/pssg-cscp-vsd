namespace Resources;

public interface ITeamRepository : IBaseRepository<Manager.Contract.Team>, IQueryRepository<TeamQuery, Manager.Contract.Team>, IFindRepository<FindTeamQuery, Manager.Contract.Team>
{
    Manager.Contract.Team Single(SingleTeamQuery query);
}
