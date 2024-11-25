﻿namespace Manager.Contract;

/// <summary>
/// Reason for the status of the Invoice
/// </summary>
public enum InvoiceStatusCode
{
    Cancelled = 100000009,
    Draft = 1,
    Duplicate = 865490002,
    Exception = 100000001,
    Negative = 100000005,
    OnHold = 100000008,
    Paid = 2,
    PendingCcReview = 865490001,
    PendingDecision = 865490000,
    Resubmit = 100000007,
    Submitted = 100000000,
}

public enum Origin
{
    AutoGenerated = 100000002,
    Email = 100000001,
    Manual = 100000003,
    Web = 100000000,
}

public enum TaxExemption
{
    AllTax = 100000003,
    GstOnly = 100000001,
    NoTax = 100000002,
    PstOnly = 100000000,
}

public record InvoiceQuery : IRequest<IEnumerable<Invoice>>
{
    public Guid? ProgramId { get; set; }
    public Origin? Origin { get; set; }
    public DateTime? InvoiceDate { get; set; }
}

public record InvoiceResult(IEnumerable<Invoice> Invoices);

public record Invoice : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public InvoiceStatusCode StatusCode { get; set; } = InvoiceStatusCode.Draft;
    public Origin Origin { get; set; }
    // TODO rename to Date
    public DateTime InvoiceDate { get; set; }
    public Guid? ContractId { get; set; }
    public Guid? OwnerId { get; set; }
    public Guid? PayeeId { get; set; }
    public Guid? ProgramId { get; set; }
    public Guid? CurrencyId { get; set; }
    public ProgramUnit ProgramUnit { get; set; }
    public InvoiceType CvapInvoiceType { get; set; }
    public TaxExemption TaxExemption { get; set; }
    public DateTime CpuScheduledPaymentDate { get; set; }
    public MethodOfPayment? MethodOfPayment { get; set; }
    public CpuInvoiceType CpuInvoiceType { get; set; }
    public Guid? ProvinceStateId { get; set; }
    public string PaymentAdviceComments { get; set; } = string.Empty;
}
