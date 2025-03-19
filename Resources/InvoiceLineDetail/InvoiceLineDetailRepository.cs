namespace Resources;

public class InvoiceLineDetailRepository : BaseRepository<Vsd_InvoiceLineDetail, InvoiceLineDetail>, IInvoiceLineDetailRepository
{
    private readonly DatabaseContext _databaseContext;

    public InvoiceLineDetailRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper) 
    { 
        _databaseContext = databaseContext;
    }

    public IEnumerable<InvoiceLineDetail> Query(InvoiceLineDetailQuery query)
    {
        var queryResults = _databaseContext.Vsd_InvoiceLineDetailSet
            .WhereIf(query.StateCode != null, c => c.StateCode == (Vsd_InvoiceLineDetail_StateCode?)query.StateCode)
            .WhereIf(query.InvoiceId != null, c => c.Vsd_InvoiceId != null && c.Vsd_InvoiceId.Id == query.InvoiceId)
            .WhereIf(query.Approved != null, x => x.Vsd_LineItemApproved == (Vsd_YesNo?)query.Approved)
            .ToList();
        return _mapper.Map<IEnumerable<InvoiceLineDetail>>(queryResults);
    }
}
