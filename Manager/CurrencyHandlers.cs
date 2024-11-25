namespace Manager;

public class CurrencyHandlers(ICurrencyRepository repository) : FindQueryBaseHandlers<ICurrencyRepository, Currency, FindCurrencyQuery, CurrencyQuery>(repository),
    IRequestHandler<CurrencyQuery, IEnumerable<Currency>>,
    IRequestHandler<FindCurrencyQuery, Currency>,
    IRequestHandler<GetCurrencyLookupCommand, Currency>
{
    public async Task<Currency> Handle(GetCurrencyLookupCommand dummy, CancellationToken token)
    {
        // query the database for CAD currency id
        var currencyQuery = new FindCurrencyQuery();
        currencyQuery.StateCode = StateCode.Active;
        currencyQuery.IsoCurrencyCode = IsoCurrencyCode.CAD.ToString();
        var currency = _repository.FirstOrDefault(currencyQuery);
        // CAD currency is static and the same on both DEV and TEST, if you need to retrieve from database, use above code instead
        //return new Currency
        //{
        //    Id = Constant.CadCurrency,
        //    IsoCurrencyCode = IsoCurrencyCode.CAD.ToString()
        //};
        return currency;
    }
}

public class GetCurrencyLookupCommand : IRequest<Currency> { }
