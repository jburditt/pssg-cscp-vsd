namespace Resources;

public class AccountRepository : IAccountRepository
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMapper _mapper;

    public AccountRepository(DatabaseContext databaseContext, IMapper mapper)
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }

    public Account FirstOrDefault(FindAccountQuery query)
    {
        var queryResults = _databaseContext.AccountSet
            .Where(query)
            .FirstOrDefault();
        return _mapper.Map<Account>(queryResults);
    }
}

public static class AccountExtensions
{
    public static IQueryable<Database.Model.Account> Where(this IQueryable<Database.Model.Account> query, BaseAccountQuery accountQuery)
    {
        return query.WhereIf(accountQuery.Id != null, c => c.Id == accountQuery.Id);
    }
}
