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

public record FindTeamQuery : BaseTeamQuery, IRequest<Team> { }

public record TeamQuery : BaseTeamQuery, IRequest<IEnumerable<Team>> { }

public record BaseTeamQuery
{
    public string? Name { get; set; }
    public TeamType? TeamType { get; set; }
}

public record Team : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public string Name { get; set; }    // Dynamics System Required
    // Foreign Keys
    public Guid? QueueId { get; set; }  // Dynamics Optional
}