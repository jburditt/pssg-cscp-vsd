﻿namespace Manager.Contract;

public enum Frequency
{
    Annually = 100000003,
    Daily = 100000001,
    Monthly = 100000002,
    Weekly = 100000000,
}

public enum ShareOptions
{
    [Description("% Allocated to Current Schedule")]
    AllocatedToCurrentSchedule_100000001 = 100000001,

    [Description("$ Allocated to Current Schedule")]
    AllocatedToCurrentSchedule_100000002 = 100000002,

    [Description("No Share")]
    NoShare = 100000000,
}

public record PaymentScheduleEntitlementQuery : IRequest<PaymentScheduleResult>
{
    public PaymentScheduleQuery? PaymentScheduleQuery { get; set; }
    public EntitlementQuery? EntitlementQuery { get; set; }
}

public record PaymentScheduleQuery : IRequest<IEnumerable<PaymentSchedule>>
{
    // PaymentSchedule
    public Guid? Id { get; set; }
    public StateCode? StateCode { get; set; }
    public DateTime? BeforeStartDate { get; set; }
    public DateTime? BeforeNextRunDate { get; set; }
    public bool? NotNullCaseId { get; set; }
    public bool? NotNullPayeeId { get; set; }
}

public record PaymentScheduleResult(PaymentSchedule PaymentSchedule, Entitlement Entitlement);

public record PaymentSchedule : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public DateTime? FirstRunDate { get; set; }             // Dynamics Optional
    public DateTime? NextRunDate { get; set; }              // Dynamics Optional
    public Frequency? Frequency { get; set; }               // Dynamics Optional
    public int? XValue { get; set; }                        // Dynamics Optional
    public decimal? PercentageDeduction { get; set; }       // Dynamics Optional
    public ShareOptions? ShareOptions { get; set; }         // Dynamics Optional
    public decimal? ShareValue { get; set; }                // Dynamics Optional
    public decimal? CppDeduction { get; set; }              // Dynamics Optional
    public decimal? OtherDeduction { get; set; }            // Dynamics Optional
    public decimal? OverPaymentEmi { get; set; }            // Dynamics Optional
    public decimal? OverPaymentAmount { get; set; }         // Dynamics Optional

    // Foreign Keys
    public Guid EntitlementId { get; set; }                 // Dynamics Business Required
}
