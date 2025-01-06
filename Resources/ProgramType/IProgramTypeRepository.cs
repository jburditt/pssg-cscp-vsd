namespace Resources;

public interface IProgramTypeRepository : IBaseRepository<ProgramType>, IFindRepository<FindProgramTypeQuery, ProgramType>, IQueryRepository<ProgramTypeQuery, ProgramType> { }
