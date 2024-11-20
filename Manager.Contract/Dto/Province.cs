using Manager.Contract;

public record ProvinceQuery : IRequest<Province>
{
    public Guid? Id { get; set; }
    public StateCode? StateCode { get; set; }
    public ProgramStatusCode? StatusCode { get; set; }
    
}

public record Province : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public decimal? TaxRate { get; set; }       // Dynamics Optional
}