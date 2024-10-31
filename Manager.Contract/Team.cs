namespace Manager.Contract;

public enum TeamType
{
    [Description("AAD Office Group")]
    AadOfficeGroup = 3,

    [Description("AAD Security Group")]
    AadSecurityGroup = 2,

    [Description("Access")]
    Access = 1,

    [Description("Owner")]
    Owner = 0,
}

public record TeamQuery : IRequest<TeamResult>
{
    public string? Name { get; set; }
    public TeamType? TeamType { get; set; }
}

public record TeamResult(IEnumerable<Team> Teams);

public record Team : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
}