namespace Resources;

public interface IProgramRepository : IBaseRepository<Program>, IFindRepository<FindProgramQuery, Program>, IQueryRepository<ProgramQuery, Program>
{
    IEnumerable<Program> GetApproved();
}
