namespace Manager;

public class AccountHandlers(IAccountRepository repository, IMapper mapper) : FindQueryBaseHandlers<IAccountRepository, Account, FindAccountQuery, AccountQuery>(repository)
{

}
