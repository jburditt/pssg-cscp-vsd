namespace Resources;

public class PaymentMapper : Profile
{
    public PaymentMapper()
    {
        CreateMap<Vsd_Payment, Payment>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Vsd_PaymentTotal.Value))
            .ForMember(dest => dest.StateCode, opt => opt.MapFrom(src => src.StateCode))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Vsd_PaymentDate))
            .ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => src.Vsd_PaymentDate))
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Vsd_PaymentTotal))
            .ForMember(dest => dest.Gst, opt => opt.MapFrom(src => src.Vsd_Gst))
            .ForMember(dest => dest.GlDate, opt => opt.MapFrom(src => src.Vsd_GLDate))
            .ForMember(dest => dest.Terms, opt => opt.MapFrom(src => src.Vsd_Terms))
            .ForMember(dest => dest.EftAdvice, opt => opt.MapFrom(src => src.Vsd_EFtAdvice))
            .ForMember(dest => dest.RemittanceMessage1, opt => opt.MapFrom(src => src.Vsd_RemittanceMessage1))
            .ForMember(dest => dest.RemittanceMessage2, opt => opt.MapFrom(src => src.Vsd_RemittanceMessage2))
            .ForMember(dest => dest.RemittanceMessage3, opt => opt.MapFrom(src => src.Vsd_RemittanceMessage3))
            .ForMember(dest => dest.CaseId, opt => opt.MapFrom(src => src.Vsd_Case))
            .ForMember(dest => dest.EntitlementId, opt => opt.MapFrom(src => src.Vsd_EntitlementId))
            .ForMember(dest => dest.Payee, opt => opt.MapFrom(src => src.Vsd_Payee))
            .ForMember(dest => dest.TransactionCurrencyId, opt => opt.MapFrom(src => src.TransactionCurrencyId.Id));

        CreateMap<Payment, Vsd_Payment>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StateCode, opt => opt.MapFrom(src => src.StateCode))
            .ForMember(dest => dest.Vsd_PaymentDate, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Vsd_PaymentSubtotal, opt => opt.MapFrom(src => src.SubTotal))
            .ForMember(dest => dest.Vsd_PaymentTotal, opt => opt.MapFrom(src => src.Total))
            .ForMember(dest => dest.Vsd_Gst, opt => opt.MapFrom(src => src.Gst))
            .ForMember(dest => dest.Vsd_GLDate, opt => opt.MapFrom(src => src.GlDate))
            .ForMember(dest => dest.Vsd_Terms, opt => opt.MapFrom(src => src.Terms))
            .ForMember(dest => dest.Vsd_EFtAdvice, opt => opt.MapFrom(src => src.EftAdvice))
            .ForMember(dest => dest.Vsd_RemittanceMessage1, opt => opt.MapFrom(src => src.RemittanceMessage1))
            .ForMember(dest => dest.Vsd_RemittanceMessage2, opt => opt.MapFrom(src => src.RemittanceMessage2))
            .ForMember(dest => dest.Vsd_RemittanceMessage3, opt => opt.MapFrom(src => src.RemittanceMessage3))
            .ForMember(dest => dest.Vsd_Case, opt => opt.MapFrom(src => src.CaseId != null ? new EntityReference("incident", src.CaseId.Value) : null))
            .ForMember(dest => dest.Vsd_EntitlementId, opt => opt.MapFrom(src => src.EntitlementId != null ? new EntityReference(Vsd_Entitlement.EntityLogicalName, src.EntitlementId.Value) : null))
            .ForMember(dest => dest.Vsd_Payee, opt => opt.MapFrom(src => src.Payee))
            .ForMember(dest => dest.TransactionCurrencyId, opt => opt.MapFrom(src => src.TransactionCurrencyId != null ? new EntityReference(TransactionCurrency.EntityLogicalName, src.TransactionCurrencyId.Value) : null));
    }
}
