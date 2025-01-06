namespace Manager.Contract;

public enum ProgramStatusCode
{
    ApplicationInfoReceived = 100000001,
    ApplicationInfoSent = 100000000,
    Archived = 2,
    BudgetProposalDraft = 100000002,
    BudgetProposalReceived = 100000006,
    BudgetProposalSent = 100000003,
    Cancelled = 100000007,
    Completed = 100000008,
    Draft = 1,
    Escalated = 100000004,
    InformationDenied = 100000005,
    ProcessingBudgetProposal = 100000009,
}

public record FindProgramQuery : BaseProgramQuery, IRequest<Program>;
public record ProgramQuery : BaseProgramQuery, IRequest<IEnumerable<Program>>;
public record BaseProgramQuery
{
    public Guid? Id { get; set; }
    public StateCode? StateCode { get; set; }
    public ProgramStatusCode? StatusCode { get; set; }
    public Guid? ContractId { get; set; }
}

public record Program : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public ProgramStatusCode? StatusCode { get; set; }          // Dynamics Optional
    public string? Name { get; set; }                           // Dynamics Optional
    public string? ProvinceState { get; set; }                  // Dynamics Business Recommended
    public DateTime? BudgetProposalSignatureDate { get; set; }  // Dynamics Optional
    public decimal? CpuSubtotal { get; set; }                   // Dynamics Optional
    public required StaticReference ProgramType { get; set; }   // Dynamics Business Required    

    // References
    public Guid ContractId { get; set; }                        // Dynamics Business Required
    public Guid OwnerId { get; set; }                           // Dynamics Business Required

    // Columns from other tables
    // TODO use StaticReference instead of string
    public required string ContractName { get; set; }           // Dynamics Business Required
}

public class GetApprovedCommand() : IRequest<IEnumerable<Program>>;
