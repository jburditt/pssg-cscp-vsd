namespace Manager.Contract;

public enum IncomeSupportParameterStatusCode
{
    //[OptionSetMetadataAttribute("Active", 1, "#0000ff")]
    Active = 1,

    //[OptionSetMetadataAttribute("Draft", 0, "#0000ff")]
    Draft = 100000000,

    //[OptionSetMetadataAttribute("Inactive", 2, "#0000ff")]
    Inactive = 2,
}

public enum IncomeSupportParameterType
{
    //[OptionSetMetadataAttribute("COLA", 0, "#0000ff")]
    Cola = 100000000,

    //[OptionSetMetadataAttribute("CPP", 2, "#0000ff")]
    Cpp = 100000002,

    //[OptionSetMetadataAttribute("Minimum Wage", 1, "#0000ff")]
    MinimumWage = 100000001,
}

public record SingleIncomeSupportParameterQuery : BaseIncomeSupportParameterQuery, IRequest<IncomeSupportParameter> { }

public record BaseIncomeSupportParameterQuery
{
    public IncomeSupportParameterType? Type { get; set; }
    public DateTime? BeforeEffectiveDate { get; set; }
    public StateCode? StateCode { get; set; }
    public IncomeSupportParameterStatusCode? StatusCode { get; set; }
    public YesNo? Validated { get; set; }
}

public record IncomeSupportParameter : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public IncomeSupportParameterStatusCode? StatusCode { get; set; }   // Dynamics Optional
    public decimal Value { get; set; }                                  // Dynamics Business Required
    public IncomeSupportParameterType Type { get; set; }                // Dynamics Business Required
    public DateTime EffectiveDate { get; set; }                         // Dynamics Business Required
    public YesNo? Validated { get; set; }                               // Dynamics Optional
}

public record GetColaCommand(DateTime EffectiveDate, decimal Cap) : IRequest<decimal> { }
