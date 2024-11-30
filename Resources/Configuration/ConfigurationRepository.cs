namespace Resources;

public class ConfigurationRepository(DatabaseContext databaseContext, IMapper mapper)
{
    //public IEnumerable<Configuration> Query(ConfigurationQuery currencyQuery)
    //{
    //    var queryResults = databaseContext.Vsd_ConfigSet
    //        .WhereIf(currencyQuery.StateCode == null, c => c.StateCode == (TransactionCurrency_StateCode?)currencyQuery.StateCode)
    //        .WhereIf(currencyQuery.IsoCurrencyCode == null, c => c.IsoCurrencyCode == currencyQuery.IsoCurrencyCode)
    //        .ToList();
    //    return mapper.Map<IEnumerable<Configuration>>(queryResults);
    //}
}

