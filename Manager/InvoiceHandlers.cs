namespace Manager;

public class InvoiceHandlers(IInvoiceRepository repository) : QueryBaseHandlers<IInvoiceRepository, Invoice, InvoiceQuery>(repository),
    IRequestHandler<InsertCommand<Invoice>, Guid>,
    IRequestHandler<InvoiceQuery, IEnumerable<Invoice>>
{

}
