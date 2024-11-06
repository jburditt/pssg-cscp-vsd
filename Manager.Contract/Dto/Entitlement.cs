namespace Manager.Contract;

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