public record FindCasPaymentQuery : BaseCasPaymentQuery, IRequest<CasPayment> { }
public record CasPaymentQuery : BaseCasPaymentQuery, IRequest<IEnumerable<CasPayment>> { }
public record BaseCasPaymentQuery
{
    public Guid? Id { get; set; }
}

public record CasPayment : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public string? ClientCode { get; set; }             // Dynamics Optional
    public string? ResponsibilityCentre { get; set; }   // Dynamics Optional
    public string? ServiceLine { get; set; }            // Dynamics Optional
    public string? Stob { get; set; }                   // Dynamics Optional
    public string? ProjectCode { get; set; }            // Dynamics Optional
}