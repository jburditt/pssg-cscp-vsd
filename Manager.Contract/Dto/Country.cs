public record FindCountryQuery : BaseCountryQuery, IRequest<Country> { }
public record SingleCountryQuery : BaseCountryQuery, IRequest<Country> { }
public record CountryQuery : BaseCountryQuery, IRequest<IEnumerable<Country>> { }
public record BaseCountryQuery
{
    public Guid? Id { get; set; }
    public StateCode? StateCode { get; set; }
    public string? Name { get; set; }
    public bool NotNullCode { get; set; }
}

public record Country : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public required string Name { get; set; }   // Dynamics Business Required   
    public string? Code { get; set; }           // Dynamics Optional
}