namespace Manager.Contract;

public record ScheduleGQuery : IRequest<IEnumerable<ScheduleG>>
{
    public Guid? Id { get; set; }
    public Guid? ProgramId { get; set; }
    public Quarter? Quarter { get; set; }
}

public record ScheduleG : IDto 
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    // Maps to DL CpuReportingPeriod
    public Quarter Quarter { get; set; }            // Dynamics Business Required

    // References
    public Guid? ServiceProviderId { get; set; }    // Dynamics Business Recommended
    public Guid ProgramId { get; set; }             // Dynamics Business Required
    public Guid? ContractId { get; set; }           // Dynamics Optional
}
