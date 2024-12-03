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

    public IEnumerable<Payment> Query(PaymentQuery paymentQuery)
    {
        var queryResults = _databaseContext.Vsd_PaymentSet
            .WhereIf(paymentQuery.ProgramId != null, p => p.Vsd_ProgramId.Id == paymentQuery.ProgramId)
            .WhereIf(paymentQuery.ContractId != null, p => p.Vsd_ContractId.Id == paymentQuery.ContractId)
            .WhereIfNotIn(paymentQuery.ExcludeStatusCodes != null, x => (PaymentStatusCode)x.StatusCode, paymentQuery.ExcludeStatusCodes)
            .ToList();
        return _mapper.Map<IEnumerable<Payment>>(queryResults);
    }
}
