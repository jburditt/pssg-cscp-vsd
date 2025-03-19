namespace Resources;

public class CurrencyRepository : BaseRepository<TransactionCurrency, Currency>, ICurrencyRepository
{
    private readonly DatabaseContext _databaseContext;

    public CurrencyRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper) 
    {
        _databaseContext = databaseContext;
    }

    public Currency FirstOrDefault(FindCurrencyQuery currencyQuery)
    {
        var queryResults = _databaseContext.TransactionCurrencySet
            .WhereIf(currencyQuery.StateCode != null, c => c.StateCode == (TransactionCurrency_StateCode?)currencyQuery.StateCode)
            .WhereIf(currencyQuery.IsoCurrencyCode != null, p => p.IsoCurrencyCode == currencyQuery.IsoCurrencyCode)
            .FirstOrDefault();
        return _mapper.Map<Currency>(queryResults);
    }

    public IEnumerable<Currency> Query(CurrencyQuery currencyQuery)
    {
        var queryResults = _databaseContext.TransactionCurrencySet
            .WhereIf(currencyQuery.StateCode != null, c => c.StateCode == (TransactionCurrency_StateCode?)currencyQuery.StateCode)
            .WhereIf(currencyQuery.IsoCurrencyCode != null, c => c.IsoCurrencyCode == currencyQuery.IsoCurrencyCode)
            .ToList();
        return _mapper.Map<IEnumerable<Currency>>(queryResults);
    }
}
