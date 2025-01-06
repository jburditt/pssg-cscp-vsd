using Manager.Contract;

public record FindProvinceQuery : BaseProvinceQuery, IRequest<Province> { }
public record SingleProvinceQuery : BaseProvinceQuery, IRequest<Province> { }
public record ProvinceQuery : BaseProvinceQuery, IRequest<IEnumerable<Province>> { }
public record BaseProvinceQuery
{
    public Guid? Id { get; set; }
    public StateCode? StateCode { get; set; }
    public ProgramStatusCode? StatusCode { get; set; }
    public string? Name { get; set; }
    public Guid? CountryId { get; set; }
    public bool NotNullCode { get; set; }
}

public record Province : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public decimal? TaxRate { get; set; }       // Dynamics Optional
    public string? Code { get; set; }           // Dynamics Optional
}