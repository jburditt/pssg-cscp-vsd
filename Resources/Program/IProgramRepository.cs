namespace Resources;

public interface IProgramRepository : IBaseRepository<Program>, IQueryRepository<ProgramQuery, Program>
{
    IEnumerable<Program> GetApproved();
}
