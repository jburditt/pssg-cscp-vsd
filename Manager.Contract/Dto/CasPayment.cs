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
}