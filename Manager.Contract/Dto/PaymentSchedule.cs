namespace Manager.Contract;

public record PaymentScheduleQuery : IRequest<IEnumerable<PaymentSchedule>>
{
    // PaymentSchedule
    public Guid? Id { get; set; }
    public StateCode? StateCode { get; set; }
    public DateTime? BeforeStartDate { get; set; }
    public DateTime? BeforeNextRunDate { get; set; }
    public bool? NotNullCaseId { get; set; }
    public bool? NotNullPayeeId { get; set; }

    // Entitlement
    public PaymentScheduleStatus? PaymentScheduleStatus { get; set; }
    public bool? IsRecurring { get; set; }
    public EntitlementStatusCode? StatusCode { get; set; }
}

public record PaymentScheduleResult(PaymentSchedule PaymentSchedule, Entitlement Entitlement);

public record PaymentSchedule : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public DateTime? FirstRunDate { get; set; }             // Dynamics Optional


    // Foreign Keys
    public Guid EntitlementId { get; set; }                 // Dynamics Business Required
}
