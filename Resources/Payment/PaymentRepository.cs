namespace Resources;

public class PaymentRepository : BaseRepository<Vsd_Payment, Payment>, IPaymentRepository
{
    private readonly DatabaseContext _databaseContext;

    public PaymentRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper) 
    {
        _databaseContext = databaseContext;
    }


    public override Guid Insert(Payment dto)
    {
        if (dto.Id == Guid.Empty)
            dto.Id = Guid.NewGuid();

        var paymentEntity = _mapper.Map<Vsd_Payment>(dto);
        
        //foreach (var invoice in payment.Vsd_Vsd_Payment_Vsd_Invoice)
        //{
        //    invoice.Id = Guid.NewGuid();
        //    invoice.Vsd_PaymentId = payment.ToEntityReference();
        //    foreach (var invoiceLineDetail in invoice.Vsd_Vsd_Invoice_Vsd_InvoiceLineDetail)
        //    {
        //        invoiceLineDetail.Id = Guid.NewGuid();
        //        invoiceLineDetail.Vsd_InvoiceId = invoice.ToEntityReference();
        //    }
        //}

        _databaseContext.AddObject(paymentEntity);

        foreach (var invoice in dto.Invoices)
        {
            var invoiceEntity = _mapper.Map<Vsd_Invoice>(invoice);
            if (invoiceEntity.Id == Guid.Empty) 
                invoiceEntity.Id = Guid.NewGuid();
            invoiceEntity.Vsd_PaymentId = paymentEntity.ToEntityReference();
            _databaseContext.AddRelatedObject(paymentEntity, Vsd_Payment.Fields.Vsd_Vsd_Payment_Vsd_Invoice.ToLower(), invoiceEntity);
            
            foreach (var invoiceLineDetail in invoice.InvoiceLineDetails)
            {
                var invoiceLineDetailEntity = _mapper.Map<Vsd_InvoiceLineDetail>(invoiceLineDetail);
                if (invoiceLineDetailEntity.Id == Guid.Empty)
                    invoiceLineDetailEntity.Id = Guid.NewGuid();
                invoiceLineDetailEntity.Vsd_InvoiceId = invoiceEntity.ToEntityReference();
                _databaseContext.AddRelatedObject(invoiceEntity, Vsd_Invoice.Fields.Vsd_Vsd_Invoice_Vsd_InvoiceLineDetail.ToLower(), invoiceLineDetailEntity);
            }
        }

        _databaseContext.SaveChanges();
        return paymentEntity.Id;
    }

    public Payment FirstOrDefault(FindPaymentQuery query) 
    {
        var queryResults = _databaseContext.Vsd_PaymentSet
            //.Join(_databaseContext.Vsd_InvoiceSet, p => p.Id, i => i.Vsd_PaymentId.Id, (p, i) => new { Payment = p, Invoice = i })
            .WhereIf(query.Id != null, x => x.Vsd_PaymentId == query.Id)
            //.Select(x => new PaymentComposite(x.Payment, x.Invoice))
            .FirstOrDefault();

        return _mapper.Map<Payment>(queryResults);
    }

    public IEnumerable<Payment> Query(PaymentQuery paymentQuery)
    {
        if (paymentQuery.IncludeChildren)
        {
            // TODO Invoice Id is empty Guid
            var query = _databaseContext.Vsd_PaymentSet
                .Join(_databaseContext.Vsd_InvoiceSet, p => p.Id, i => i.Vsd_PaymentId.Id, (p, i) => new { Payment = p, Invoice = i })
                .WhereIf(paymentQuery.ProgramId != null, p => p.Payment.Vsd_ProgramId.Id == paymentQuery.ProgramId)
                .WhereIf(paymentQuery.ContractId != null, p => p.Payment.Vsd_ContractId.Id == paymentQuery.ContractId)
                .WhereIf(paymentQuery.StateCode != null, p => p.Payment.StateCode == (Vsd_Payment_StateCode)paymentQuery.StateCode)
                .WhereIf(paymentQuery.StatusCode != null, p => p.Payment.StatusCode == (Vsd_Payment_StatusCode?)paymentQuery.StatusCode)
                .WhereIfNotIn(paymentQuery.ExcludeStatusCodes != null, x => (PaymentStatusCode)x.Payment.StatusCode, paymentQuery.ExcludeStatusCodes);

            var queryResults = query
                .ToList()
                .GroupBy(x => x.Payment, x => x.Invoice, (p, i) => new PaymentInvoicesEntity(p, i));

            return _mapper.Map<IEnumerable<Payment>>(queryResults);
        }
        else
        {
            var queryResults = _databaseContext.Vsd_PaymentSet
                .Where(paymentQuery)
                .ToList();
            return _mapper.Map<IEnumerable<Payment>>(queryResults);
        }
    }

    // TODO refactor to use Update(Func<TDto, object> updateExpression)
    public bool UpdatePaymentCas(UpdatePaymentCasCommand command) 
    {
        var entity = new Vsd_Payment();
        _databaseContext.Attach(entity);
        entity.Id = command.Id;
        entity.Vsd_CasResponse = command.CasResponse;
        entity.StatusCode = (Vsd_Payment_StatusCode)command.StatusCode;
        entity.Vsd_PaymentDate = command.Date;
        _databaseContext.UpdateObject(entity);
        return !_databaseContext
            .SaveChanges()
            .HasError;       
    }
}

public record PaymentInvoicesEntity(Vsd_Payment Payment, IEnumerable<Vsd_Invoice> Invoices);

public static class PaymentExtensions
{
    public static IQueryable<Vsd_Payment> Where(this IQueryable<Vsd_Payment> query, BasePaymentQuery paymentQuery)
    {
        return query
            .WhereIf(paymentQuery.StateCode != null, x => x.StateCode == (Vsd_Payment_StateCode?)paymentQuery.StateCode)
            .WhereIf(paymentQuery.StatusCode != null, x => x.StatusCode == (Vsd_Payment_StatusCode?)paymentQuery.StatusCode)
            .WhereIf(paymentQuery.BeforeDate != null, x => x.Vsd_PaymentDate <= paymentQuery.BeforeDate)
            .WhereIf(paymentQuery.ProgramId != null, p => p.Vsd_ProgramId.Id == paymentQuery.ProgramId)
            .WhereIf(paymentQuery.ContractId != null, p => p.Vsd_ContractId.Id == paymentQuery.ContractId)
            .WhereIfNotIn(paymentQuery.ExcludeStatusCodes != null, x => (PaymentStatusCode)x.StatusCode, paymentQuery.ExcludeStatusCodes);
    }
}