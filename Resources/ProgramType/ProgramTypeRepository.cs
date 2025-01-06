namespace Resources;

public class ProgramTypeRepository : BaseRepository<Vsd_ProgramType, ProgramType>, IProgramTypeRepository
{
    private readonly DatabaseContext _databaseContext;

    public ProgramTypeRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper) 
    {
        _databaseContext = databaseContext;
    }

    public ProgramType FirstOrDefault(FindProgramTypeQuery query)
    {
        var entities = _databaseContext.Vsd_ProgramTypeSet
            .Where(query)
            .FirstOrDefault();
        return _mapper.Map<ProgramType>(entities);
    }

    public IEnumerable<ProgramType> Query(ProgramTypeQuery query)
    {
        var entities = _databaseContext.Vsd_ProgramTypeSet
            .Where(query)
            .ToList();
        return _mapper.Map<IEnumerable<ProgramType>>(entities);
    }
}

public static class ProgramTypeExtensions
{
    public static IQueryable<Vsd_ProgramType> Where(this IQueryable<Vsd_ProgramType> query, BaseProgramTypeQuery ProgramTypeQuery)
    {
        return query
            .WhereIf(ProgramTypeQuery.Id != null, x => x.Id == ProgramTypeQuery.Id)
            .WhereIf(ProgramTypeQuery.ClientCode != null, x => x.Vsd_ClientCode == ProgramTypeQuery.ClientCode)
            .WhereIf(ProgramTypeQuery.ResponsibilityCentre != null, c => c.Vsd_ResponsibilityCentre == ProgramTypeQuery.ResponsibilityCentre)
            .WhereIf(ProgramTypeQuery.ServiceLine != null, c => c.Vsd_ServiceLine == ProgramTypeQuery.ServiceLine)
            .WhereIf(ProgramTypeQuery.Stob != null, c => c.Vsd_SToB == ProgramTypeQuery.Stob)
            .WhereIf(ProgramTypeQuery.ProjectCode != null, c => c.Vsd_ProjectCode == ProgramTypeQuery.ProjectCode);
    }
}
