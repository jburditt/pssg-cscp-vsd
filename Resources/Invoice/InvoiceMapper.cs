namespace Resources;

public class InvoiceMapper : Profile
{
    public InvoiceMapper()
    {
        CreateMap<Vsd_Invoice, Invoice>()
            .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Vsd_Name))
            .ForMember(dest => dest.CasPayment, opts => opts.MapFrom(src => src.Vsd_CasPaymentType))
            .ForMember(dest => dest.CpuInvoiceType, opts => opts.MapFrom(src => src.Vsd_Cpu_InvoiceType))
            .ForMember(dest => dest.CpuScheduledPaymentDate, opts => opts.MapFrom(src => src.Vsd_Cpu_ScheduledPaymentDate))
            .ForMember(dest => dest.CurrencyId, opts => opts.MapFrom(src => src.TransactionCurrencyId.Id))
            .ForMember(dest => dest.CvapInvoiceType, opts => opts.MapFrom(src => src.Vsd_Cvap_InvoiceType))
            .ForMember(dest => dest.ProgramUnit, opts => opts.MapFrom(src => (ProgramUnit?)src.Vsd_ProgramUnit))
            .ForMember(dest => dest.ContractId, opts => opts.MapFrom(src => src.Vsd_ContractId.Id))
            .ForMember(dest => dest.Owner, opts => opts.MapFrom(src => src.OwnerId))
            .ForMember(dest => dest.ProgramId, opts => opts.MapFrom(src => src.Vsd_ProgramId.Id))
            .ForMember(dest => dest.ProvinceStateId, opts => opts.MapFrom(src => src.Vsd_ProvinceStateId.Id))
            .ForMember(dest => dest.InvoiceDate, opts => opts.MapFrom(src => src.Vsd_InvoicedAte))
            .ForMember(dest => dest.EntitlementId, opts => opts.MapFrom(src => src.Vsd_EntitlementId))
            .ForMember(dest => dest.EntitlementName, opts => opts.MapFrom(src => src.Vsd_EntitlementIdName))
            .ForMember(dest => dest.Payee, opts => opts.MapFrom(src => src.Vsd_Payee))
            .ForMember(dest => dest.PaymentId, opts => opts.MapFrom(src => src.Vsd_PaymentId.Id))
            .ForMember(dest => dest.EntitlementId, opts => opts.MapFrom(src => src.Vsd_EntitlementId.Id))
            .ForMember(dest => dest.PaymentScheduleId, opts => opts.MapFrom(src => src.Vsd_PaymentScheduleId.Id))
            .ForMember(dest => dest.Validator, opts => opts.MapFrom(src => src.Vsd_User3));

        CreateMap<Invoice, Vsd_Invoice>()
            .ForMember(dest => dest.Vsd_Name, opts => opts.MapFrom(src => src.Name))
            .ForMember(dest => dest.Vsd_CasPaymentType, opts => opts.MapFrom(src => src.CasPayment))
            .ForMember(dest => dest.Vsd_Cpu_InvoiceType, opts => opts.MapFrom(src => src.CpuInvoiceType))
            .ForMember(dest => dest.Vsd_Cpu_ScheduledPaymentDate, opts => opts.MapFrom(src => src.CpuScheduledPaymentDate))
            .ForMember(dest => dest.TransactionCurrencyId, opts => opts.MapFrom(src => src.CurrencyId != null ? new EntityReference(TransactionCurrency.EntityLogicalName, src.CurrencyId.Value) : null))
            .ForMember(dest => dest.Vsd_Cvap_InvoiceType, opts => opts.MapFrom(src => src.CvapInvoiceType))
            .ForMember(dest => dest.Vsd_ProgramUnit, opts => opts.MapFrom(src => (Vsd_ProgramUnit?)src.ProgramUnit))
            .ForMember(dest => dest.Vsd_InvoicedAte, opts => opts.MapFrom(src => src.InvoiceDate))
            .ForMember(dest => dest.Vsd_ContractId, opts => opts.MapFrom(src => src.ContractId != null ? new EntityReference(Vsd_Contract.EntityLogicalName, src.ContractId.Value) : null))
            .ForMember(dest => dest.OwnerId, opts => opts.MapFrom(src => new EntityReference(src.Owner.SchemaName, src.Owner.Id)))
            .ForMember(dest => dest.Vsd_ProgramId, opts => opts.MapFrom(src => src.ProgramId != null ? new EntityReference(Vsd_Program.EntityLogicalName, src.ProgramId.Value) : null))
            .ForMember(dest => dest.Vsd_ProvinceStateId, opts => opts.MapFrom(src => src.ProvinceStateId != null ? new EntityReference(Vsd_Province.EntityLogicalName, src.ProvinceStateId.Value) : null))
            .ForMember(dest => dest.Vsd_EntitlementId, opts => opts.MapFrom(src => src.EntitlementId))
            .ForMember(dest => dest.Vsd_EntitlementIdName, opts => opts.MapFrom(src => src.EntitlementName))
            .ForMember(dest => dest.Vsd_Payee, opts => opts.MapFrom(src => src.Payee))
            .ForMember(dest => dest.Vsd_PaymentId, opts => opts.MapFrom(src => src.PaymentId != null ? new EntityReference(Vsd_Payment.EntityLogicalName, src.PaymentId.Value) : null))
            .ForMember(dest => dest.Vsd_EntitlementId, opts => opts.MapFrom(src => src.EntitlementId != null ? new EntityReference(Vsd_Entitlement.EntityLogicalName, src.EntitlementId.Value) : null))
            .ForMember(dest => dest.Vsd_PaymentScheduleId, opts => opts.MapFrom(src => src.PaymentScheduleId != null ? new EntityReference(Vsd_PaymentSchedule.EntityLogicalName, src.PaymentScheduleId.Value) : null))
            .ForMember(dest => dest.Vsd_User3, opts => opts.MapFrom(src => src.Validator));

    }
}
