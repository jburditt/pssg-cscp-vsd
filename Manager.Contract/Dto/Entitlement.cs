namespace Manager.Contract;

public enum PaymentScheduleStatus
{
    Active = 100000000,
    Cancelled = 100000002,
    Modified = 100000003,
    Pause = 100000001,
}

public enum EntitlementStatusCode
{
    [Description("Approved")]
    Approved = 100000000,

    [Description("Created in Error")]
    CreatedInError = 100000003,

    [Description("Denied")]
    Denied = 2,

    [Description("Paid")]
    Paid = 100000004,

    [Description("Pending")]
    Pending = 100000001,

    [Description("Requested")]
    Requested = 1,

    [Description("Suspended")]
    Suspended = 100000005,

    [Description("Terminated")]
    Terminated = 100000006,

    [Description("Withdrawn")]
    Withdrawn = 100000002,
}

public enum EntitlementStage
{
    [Description("Ready for CC")]   // 0
    ReadyForCc = 100000000,

    [Description("Ready for TL")]   // 1
    ReadyForTl = 100000001,
}

public enum ApplicantType
{
    [Description("Civil Protected Party")]  // 0
    CivilProtectedParty = 100000005,

    [Description("IFM")]      // 1
    Ifm = 100000001,

    [Description("Offender")] // 2
    Offender = 100000003,

    [Description("Other")]    // 3
    Other = 100000004,

    [Description("Victim")]   // 4
    Victim = 100000002,

    [Description("Witness")]  // 5
    Witness = 100000000,
}

public record EntitlementQuery : IRequest<IEnumerable<Entitlement>>
{
    public Guid? Id { get; set; }
    public PaymentScheduleStatus? PaymentScheduleStatus { get; set; }
    public bool? IsRecurring { get; set; }
    public EntitlementStatusCode? StatusCode { get; set; }
}

public record Entitlement : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public EntitlementStatusCode StatusCode { get; set; }
    public EntitlementStage EntitlementStage { get; set; }              // Dynamics Optional
    // Dynamics Business Required but still NULL in database e.g. https://cscp-vs.dev.jag.gov.bc.ca/api/data/v9.0/vsd_entitlements?$filter=vsd_entitlementid%20eq%20%27{14a5d13d-6e2f-ed11-b834-00505683fbf4}%27
    public DateTime EffectiveDate { get; set; }                         // Dynamics Business Required 
    public decimal? SetCap { get; set; }                                // Dynamics Optional
    public bool? TaxExemptFlag { get; set; }                            // Dynamics Optional
    public decimal? FinanciallyDependentIfmWage { get; set; }           // Dynamics Optional
    public decimal? CvapAvailableEntitilement { get; set; }             // Dynamics Optional
    public PaymentScheduleStatus? PaymentScheduleStatus { get; set; }   // Dynamics Optional
    public bool? IsRecurring { get; set; }                              // Dynamics Optional
    public required StaticReference Case { get; set; }                  // Dynamics Business Required
    public ApplicantType? ApplicantType { get; set; }                   // Dynamics Optional
    public PaymentScheduleStatus? paymentScheduleStatus { get; set; }   // Dynamics Optional

    // Foreign Keys
    public Guid BenefitCategoryId { get; set; }             // Dynamics Business Required
    public Guid? BenefitTypeId { get; set; }                // Dynamics Business Recommended
    // TODO just use StaticReference instead of the below two fields
    public Guid? BenefitSubTypeId { get; set; }             // Dynamics Optional
    public string? BenefitSubTypeName { get; set; }         // Inherently Dynamics Optional
}

public record UpdatePaymentScheduleStatus(Guid Id, PaymentScheduleStatus PaymentScheduleStatus) : IRequest<bool> { }