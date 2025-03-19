namespace Resources;

public interface IInvoiceRepository : IQueryRepository<InvoiceQuery, Invoice>, IBaseRepository<Invoice>
{

}