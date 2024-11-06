namespace Manager.Contract;

public record Entitlement : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
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