namespace Resources;

public interface ICasPaymentRepository : IFindRepository<FindCasPaymentQuery, CasPayment>, IQueryRepository<CasPaymentQuery, CasPayment> { }
