namespace Manager;

public class InvoiceLineDetailHandlers(IInvoiceLineDetailRepository repository) : QueryBaseHandlers<IInvoiceLineDetailRepository, InvoiceLineDetail, InvoiceLineDetailQuery>(repository),
    //IRequestHandler<InsertCommand<InvoiceLineDetail>, Guid>
    IRequestHandler<InvoiceLineDetailQuery, IEnumerable<InvoiceLineDetail>>
{
    public async Task<IEnumerable<InvoiceLineDetail>> Handle(InvoiceLineDetailQuery query, CancellationToken cancellationToken)
    {
        var results = repository.Query(query);
        return await Task.FromResult(results);
    }
}
