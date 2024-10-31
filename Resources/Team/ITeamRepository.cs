namespace Resources;

public interface ITeamRepository : IBaseRepository<Manager.Contract.Team>, IFindRepository<TeamQuery, Manager.Contract.Team>
{
}
