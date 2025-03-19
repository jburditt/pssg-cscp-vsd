namespace Resources;

public interface ICurrencyRepository : IFindRepository<FindCurrencyQuery, Currency>, IQueryRepository<CurrencyQuery, Currency>, IBaseRepository<Currency>
{

}
