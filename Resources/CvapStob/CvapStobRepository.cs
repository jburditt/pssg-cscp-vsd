namespace Resources;

public class CvapStobRepository : BaseRepository<Vsd_CvapStOB, CvapStob>, ICvapStobRepository
{
    private readonly DatabaseContext _databaseContext;

    public CvapStobRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
        _databaseContext = databaseContext;
    }

    public CvapStob FirstOrDefault(FindCvapStobQuery query)
    {
        var queryResults = _databaseContext.Vsd_CvapStOBSet
            .WhereIf(query.Id != null, c => c.Id == query.Id)
            .FirstOrDefault();
        return _mapper.Map<CvapStob>(queryResults);
    }

    public IEnumerable<CvapStob> Query(CvapStobQuery query)
    {
        var queryResults = _databaseContext.Vsd_CvapStOBSet
            .WhereIf(query.Id != null, c => c.Id == query.Id)
            .ToList();
        return _mapper.Map<IEnumerable<CvapStob>>(queryResults);
    }
}

public static class CvapStobExtensions
{
    public static IQueryable<Vsd_CvapStOB> Where(this IQueryable<Vsd_CvapStOB> query, BaseCvapStobQuery CvapStobQuery)
    {
        return query.WhereIf(CvapStobQuery.Id != null, c => c.Id == CvapStobQuery.Id);
    }
}
