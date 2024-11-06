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


public record Entitlement : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    // Dynamics Business Required but still NULL in database e.g. https://cscp-vs.dev.jag.gov.bc.ca/api/data/v9.0/vsd_entitlements?$filter=vsd_entitlementid%20eq%20%27{14a5d13d-6e2f-ed11-b834-00505683fbf4}%27
    public DateTime EffectiveDate { get; set; }             // Dynamics Business Required 
    public decimal? SetCap { get; set; }                    // Dynamics Optional
    public bool? TaxExemptFlag { get; set; }                // Dynamics Optional
    public decimal? FinanciallyDependentIfmWage { get; set; }   // Dynamics Optional
    public decimal? CvapAvailableEntitilement { get; set; }     // Dynamics Optional

    // Foreign Keys
    public Guid BenefitCategoryId { get; set; }             // Dynamics Business Required
    public Guid? BenefitTypeId { get; set; }                // Dynamics Business Recommended
    public Guid? BenefitSubTypeId { get; set; }             // Dynamics Optional
}