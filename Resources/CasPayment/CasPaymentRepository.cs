namespace Resources;

public class CasPaymentRepository : ICasPaymentRepository
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMapper _mapper;

    public CasPaymentRepository(DatabaseContext databaseContext, IMapper mapper)
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }

    public CasPayment FirstOrDefault(FindCasPaymentQuery query)
    {
        var queryResults = _databaseContext.Vsd_CasPaymentTypeSet
            .WhereIf(query.Id != null, c => c.Id == query.Id)
            .FirstOrDefault();
        return _mapper.Map<CasPayment>(queryResults);
    }

    public IEnumerable<CasPayment> Query(CasPaymentQuery query)
    {
        var queryResults = _databaseContext.Vsd_CasPaymentTypeSet
            .WhereIf(query.Id != null, c => c.Id == query.Id)
            .ToList();
        return _mapper.Map<IEnumerable<CasPayment>>(queryResults);
    }
}

public static class CasPaymentExtensions
{
    public static IQueryable<Vsd_CasPaymentType> Where(this IQueryable<Vsd_CasPaymentType> query, BaseCasPaymentQuery casPaymentQuery)
    {
        return query.WhereIf(casPaymentQuery.Id != null, c => c.Id == casPaymentQuery.Id);
    }
}
