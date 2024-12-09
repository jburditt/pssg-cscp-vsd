namespace Manager.Contract;

public record InvoiceLineDetailQuery : IRequest<IEnumerable<InvoiceLineDetail>>
{
    public Guid? Id { get; set; }
    public Guid? InvoiceId { get; set; }
    public StateCode? StateCode { get; set; }
    public YesNo? Approved { get; set; }
}

public record InvoiceLineDetail : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public InvoiceType? InvoiceType { get; set; }   // Dynamics Optional
    public ProgramUnit? ProgramUnit { get; set; }   // Dynamics Optional
    public YesNo? Approved { get; set; }            // Dynamics Optional
    public decimal? AmountSimple { get; set; }      // Dynamics Optional
    public decimal? AmountCalculated { get; set; }  // Dynamics Optional
    public decimal? TotalAmount { get; set; }       // Dynamics Optional
    public TaxExemption? TaxExemption { get; set; } // Dynamics Optional

    // References
    public Guid InvoiceId { get; set; }                     // Dynamics Business Required
    public required DynamicReference Owner { get; set; }    // Dynamics System Required
    public Guid? ProvinceStateId { get; set; }              // Dynamics Optional
    public Guid? CaseId { get; set; }                       // Dynamics Optional
    public Guid? EntitlementId { get; set; }                // Dynamics Optional
    public Guid CurrencyId { get; set; }                    // Dynamics System Required
}
