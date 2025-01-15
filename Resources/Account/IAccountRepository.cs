namespace Resources;

public interface IAccountRepository : IFindRepository<FindAccountQuery, Account>, IQueryRepository<AccountQuery, Account>, IBaseRepository<Account> { }
