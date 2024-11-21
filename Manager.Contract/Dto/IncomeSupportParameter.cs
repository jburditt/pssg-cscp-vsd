namespace Manager.Contract;

public record SingleIncomeSupportParamterQuery : BaseIncomeSupportParameterQuery, IRequest<IncomeSupportParameter> { }

public record BaseIncomeSupportParameterQuery
{
    public IncomeSupportParameter.Type? Type { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public StateCode? StateCode { get; set; }
    public IncomeSupportParameter.StatusCode? StatusCode { get; set; }
    public YesNo Validated { get; set; }
}

public record IncomeSupportParameter
{
    public decimal? Value { get; set; }

    public enum StatusCode
    {
        //[OptionSetMetadataAttribute("Active", 1, "#0000ff")]
        Active = 1,

        //[OptionSetMetadataAttribute("Draft", 0, "#0000ff")]
        Draft = 100000000,

        //[OptionSetMetadataAttribute("Inactive", 2, "#0000ff")]
        Inactive = 2,
    }

    public enum Type
    {
        //[OptionSetMetadataAttribute("COLA", 0, "#0000ff")]
        Cola = 100000000,

        //[OptionSetMetadataAttribute("CPP", 2, "#0000ff")]
        Cpp = 100000002,

        //[OptionSetMetadataAttribute("Minimum Wage", 1, "#0000ff")]
        MinimumWage = 100000001,
    }
}

