namespace Manager.Contract;

public enum PaymentStatusCode
{
    Canceled = 100000007,
    Failed = 100000003,
    NeedManualIntervention = 100000009,
    Negative = 100000006,
    OnHold = 100000008,
    Paid = 2,
    Sending = 100000001,
    Sent = 100000002,
    Voided = 100000010,
    Waiting = 100000000,
}

public enum PaymentTerms
{
    [Description("20 Days")]
    _20Days = 100000000,

    [Description("Immediate")]
    Immediate = 100000001,
}

public enum EftAdvice
{
    [Description("Email")]
    Email = 100000000,

    [Description("Mail")]
    Mail = 100000001,
}

public record FindPaymentQuery : BasePaymentQuery, IRequest<Payment> { }
public record PaymentQuery : BasePaymentQuery, IRequest<IEnumerable<Payment>> { }
public record BasePaymentQuery
{
    public Guid? Id { get; set; }
    public StateCode? StateCode { get; set; }
    public PaymentStatusCode? StatusCode { get; set; }
    public List<PaymentStatusCode>? ExcludeStatusCodes { get; set; }
    public DateTime? Date { get; set; }
    public Guid? ProgramId { get; set; }
    public Guid? ContractId { get; set; }
    public bool IncludeChildren { get; set; }
}

public record Payment : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public DateTime Date { get; set; }                  // Dynamics Business Required
    public decimal? SubTotal { get; set; }              // Dynamics Optional
    public decimal? Total { get; set; }                 // Dynamics Optional
    public decimal? Gst { get; set; }                   // Dynamics Optional
    public DateTime GlDate { get; set; }                // Dynamics Business Required
    public PaymentTerms? Terms { get; set; }            // Dynamics Optional
    public EftAdvice? EftAdvice { get; set; }           // Dynamics Optional
    public string? RemittanceMessage1 { get; set; }     // Dynamics Optional
    public string? RemittanceMessage2 { get; set; }     // Dynamics Optional
    public string? RemittanceMessage3 { get; set; }     // Dynamics Optional

    // Foreign Keys
    public Guid? CaseId { get; set; }                   // Dynamics Optional
    public Guid? EntitlementId { get; set; }            // Dynamics Optional
    public DynamicReference? Payee { get; set; }        // Dynamics Optional
    // TODO rename to CurrencyId
    public Guid? TransactionCurrencyId { get; set; }    // Dynamics Optional

    // Foreign Objects
    public IEnumerable<Invoice>? Invoices { get; set; }
}
