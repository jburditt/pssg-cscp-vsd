namespace Manager.Contract;

public enum IsoCurrencyCode
{
    CAD
}

// TODO consolidate all FindXQuery and XQuery records
public record FindCurrencyQuery : IRequest<Currency>
{
    public StateCode? StateCode { get; set; }
    public string? IsoCurrencyCode { get; set; }
}

public record CurrencyQuery : IRequest<IEnumerable<Currency>>
{
    public StateCode? StateCode { get; set; }
    public string? IsoCurrencyCode { get; set; }
}

public record Currency : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public StatusCode? StatusCode { get; set; }             // Dynamics Optional
    public required string IsoCurrencyCode { get; set; }    // Dynamics System Required
}

public class GetCurrencyLookupCommand : IRequest<Currency> { }
