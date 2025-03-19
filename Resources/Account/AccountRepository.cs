namespace Resources;

public class AccountRepository : BaseRepository<Database.Model.Account, Account>, IAccountRepository
{
    private readonly DatabaseContext _databaseContext;

    public AccountRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
        _databaseContext = databaseContext;
    }

    public Account FirstOrDefault(FindAccountQuery query)
    {
        var entity = _databaseContext.AccountSet
            .Where(query)
            .FirstOrDefault();
        return _mapper.Map<Account>(entity);
    }

    public IEnumerable<Account> Query(AccountQuery query)
    {
        var entities = _databaseContext.AccountSet
            .Where(query)
            .FirstOrDefault();
        return _mapper.Map<IEnumerable<Account>>(entities);
    }
}

public static class AccountExtensions
{
    public static IQueryable<Database.Model.Account> Where(this IQueryable<Database.Model.Account> query, BaseAccountQuery accountQuery)
    {
        return query.WhereIf(accountQuery.Id != null, c => c.Id == accountQuery.Id);
    }
}
