namespace Resources;

public class InvoiceRepository : BaseRepository<Vsd_Invoice, Invoice>, IInvoiceRepository
{
    private readonly DatabaseContext _databaseContext;

    public InvoiceRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper) 
    {
        _databaseContext = databaseContext;
    }

    // TODO use paymentrepository.insert as a template
    // NOTE not fully tested
    public override Guid Insert(Invoice invoice)
    {
        // TODO check Id is a Guid and not empty
        var entity = _mapper.Map<Vsd_Invoice>(invoice);
        // TODO check if you should move this line to before SaveChanges
        _databaseContext.AddObject(entity);
        if (invoice.InvoiceLineDetails != null)
        {
            foreach (var invoiceLineDetailDto in invoice.InvoiceLineDetails)
            {
                var invoiceLineDetail = _mapper.Map<Vsd_InvoiceLineDetail>(invoiceLineDetailDto);
                invoiceLineDetail.Vsd_InvoiceId = entity.ToEntityReference();
                _databaseContext.AddRelatedObject(entity, Vsd_Invoice.Fields.Vsd_Vsd_Invoice_Vsd_InvoiceLineDetail.ToLower(), invoiceLineDetail);
            }
        }
        _databaseContext.SaveChanges();
        return entity.Id;
    }

    public IEnumerable<Invoice> Query(InvoiceQuery query)
    {
        if (query.IncludeChildren)
        {
            // TODO not fully tested, use paymentrepository.query to finish
            var queryResults = _databaseContext.Vsd_InvoiceSet
                .Join(_databaseContext.Vsd_InvoiceLineDetailSet, invoice => invoice.Id, invoiceLineDetail => invoiceLineDetail.Vsd_InvoiceId.Id, (invoice, invoiceLineDetail) => new { Invoice = invoice, InvoiceLineDetail = invoiceLineDetail })
                .WhereIf(query.Id != null, c => c.Invoice.Id == query.Id)
                .WhereIf(query.ProgramId != null, c => c.Invoice.Vsd_ProgramId.Id == query.ProgramId)
                .WhereIf(query.Origin != null, c => c.Invoice.Vsd_Origin == (Vsd_Invoice_Vsd_Origin?)query.Origin)
                .WhereIf(query.InvoiceDate != null, c => c.Invoice.Vsd_InvoicedAte == query.InvoiceDate)
                .Select(x => new { x.Invoice, x.InvoiceLineDetail })
                .ToList();
            return _mapper.Map<IEnumerable<Invoice>>(queryResults);
        }
        else
        {
            var queryResults = _databaseContext.Vsd_InvoiceSet
                .WhereIf(query.ProgramId != null, c => c.Vsd_ProgramId.Id == query.ProgramId)
                .WhereIf(query.Origin != null, c => c.Vsd_Origin == (Vsd_Invoice_Vsd_Origin?)query.Origin)
                .WhereIf(query.InvoiceDate != null, c => c.Vsd_InvoicedAte == query.InvoiceDate)
                .ToList();
            return _mapper.Map<IEnumerable<Invoice>>(queryResults);
        }
    }

    public record InvoiceComposite(Vsd_Invoice Invoice, Vsd_InvoiceLineDetail InvoiceLineDetail);


    public override bool Delete(Guid id)
    {
        var invoiceLineDetails = _databaseContext.Vsd_InvoiceLineDetailSet
            .Where(x => x.Vsd_InvoiceId.Id == id)
            .ToList();
        foreach (var invoiceLineDetail in invoiceLineDetails)
        {
            _databaseContext.DeleteObject(invoiceLineDetail);
            _databaseContext.SaveChanges();
            _databaseContext.Detach(invoiceLineDetail);
        }
        return base.Delete(id);
    }

    public override bool TryDeleteRange(IEnumerable<Invoice> invoices, bool isRecursive = false)
    {
        // NOTE you can optimize these by removing the foreach queries and using Invoice.InvoiceLineDetailId instead but you will need to map InvoiceLineDetailId first on Query method
        //foreach (var invoice in invoices)
        //{
        //    var invoiceLineDetails = _databaseContext.Vsd_InvoiceLineDetailSet.Where(x => x.Vsd_InvoiceId.Id == invoice.Id).ToList();
        //    foreach (var invoiceLineDetail in invoiceLineDetails)
        //    {
        //        // TODO a false here should return false for this method
        //        _databaseContext.DeleteObject(invoiceLineDetail);
        //        _databaseContext.SaveChanges();
        //        _databaseContext.Detach(invoiceLineDetail);
        //    }
        //}

        return base.TryDeleteRange(invoices);
    }
}
