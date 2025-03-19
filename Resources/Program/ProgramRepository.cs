namespace Resources;

public class ProgramRepository : BaseRepository<Vsd_Program, Program>, IProgramRepository
{
    private readonly DatabaseContext _databaseContext;

    public ProgramRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper) 
    {
        _databaseContext = databaseContext;
    }

    public Program FirstOrDefault(FindProgramQuery programQuery)
    {
        var queryResults = _databaseContext.Vsd_ProgramSet
            .Where(programQuery)
            .FirstOrDefault();
        return _mapper.Map<Program>(queryResults);
    }

    public IEnumerable<Program> Query(ProgramQuery programQuery)
    {
        var queryResults = _databaseContext.Vsd_ProgramSet
            .Where(programQuery)
            .ToList();
        return _mapper.Map<IEnumerable<Program>>(queryResults);
    }

    // TODO refactor this to be a Query that includes children, use PaymentRepository.Query as an example
    public IEnumerable<Program> GetApproved()
    {
        var queryResults = (
            from p in _databaseContext.Vsd_ProgramSet
            join c in _databaseContext.Vsd_ContractSet on p.Vsd_ContractId.Id equals c.Vsd_ContractId
            where p.StateCode == Vsd_Program_StateCode.Active
            where p.StatusCode != Vsd_Program_StatusCode.Draft && p.StatusCode != Vsd_Program_StatusCode.ApplicationInfoSent && p.StatusCode != Vsd_Program_StatusCode.ApplicationInfoReceived
            where c.StatusCode == Vsd_Contract_StatusCode.DulyExecuted
            where c.Vsd_Type != Vsd_ContractType.TuaCommunityAccountabilityPrograms
            select p)
                .ToList();
        return _mapper.Map<IEnumerable<Program>>(queryResults);
    }
}

public static class ProgramExtensions
{
    public static IQueryable<Vsd_Program> Where(this IQueryable<Vsd_Program> query, BaseProgramQuery programQuery)
    {
        return query
            .WhereIf(programQuery.Id != null, x => x.Id == programQuery.Id)
            .WhereIf(programQuery.ContractId != null, x => x.Vsd_ContractId.Id == programQuery.ContractId)
            .WhereIf(programQuery.StateCode != null, c => c.StateCode == (Vsd_Program_StateCode)programQuery.StateCode)
            .WhereIf(programQuery.StatusCode != null, c => c.StatusCode == (Vsd_Program_StatusCode)programQuery.StatusCode);
    }
}
