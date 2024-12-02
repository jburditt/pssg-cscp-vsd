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
        {
            dto.Id = Guid.NewGuid();
        }

        var payment = _mapper.Map<Vsd_Payment>(dto);

        foreach (var invoice in payment.Vsd_Vsd_Payment_Vsd_Invoice)
        {
            invoice.Id = Guid.NewGuid();
            invoice.Vsd_PaymentId = payment.ToEntityReference();
            foreach (var invoiceLineDetail in invoice.Vsd_Vsd_Invoice_Vsd_InvoiceLineDetail)
            {
                invoiceLineDetail.Id = Guid.NewGuid();
                invoiceLineDetail.Vsd_InvoiceId = invoice.ToEntityReference();
            }
        }

        _databaseContext.AddObject(payment);
        _databaseContext.SaveChanges();
        return payment.Id;
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
