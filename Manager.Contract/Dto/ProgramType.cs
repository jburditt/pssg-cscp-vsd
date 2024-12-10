namespace Manager.Contract;

public record FindProgramTypeQuery : BaseProgramTypeQuery, IRequest<ProgramType>;
public record ProgramTypeQuery : BaseProgramTypeQuery, IRequest<IEnumerable<ProgramType>>;
public record BaseProgramTypeQuery
{
    public Guid? Id { get; set; }
    public StateCode? StateCode { get; set; }
    public string? ClientCode { get; set; }
    public string? ResponsibilityCentre { get; set; }
    public string? ServiceLine { get; set; }
    public string? Stob { get; set; }
    public string? ProjectCode { get; set; }
}

public record ProgramType : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public string? ClientCode { get; set; }
    public string? ResponsibilityCentre { get; set; }
    public string? ServiceLine { get; set; }
    public string? Stob { get; set; }
    public string? ProjectCode { get; set; }
}
