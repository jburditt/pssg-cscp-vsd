namespace Resources;

public class CurrencyMapper : Profile
{
    public CurrencyMapper()
    {
        CreateMap<TransactionCurrency, Currency>();
    }
}
