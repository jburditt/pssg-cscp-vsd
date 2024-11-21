namespace Resources;

public class PaymentRepositoryMapper : Profile
{
    public PaymentRepositoryMapper()
    {
        CreateMap<Vsd_Payment, Payment>()
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Vsd_PaymentTotal.Value));

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
            .ForMember(dest => dest.Vsd_Case, opt => opt.MapFrom(src => src.CaseId))
            .ForMember(dest => dest.Vsd_EntitlementId, opt => opt.MapFrom(src => src.EntitlementId))
            .ForMember(dest => dest.Vsd_Payee, opt => opt.MapFrom(src => src.Payee))
            .ForMember(dest => dest.TransactionCurrencyId, opt => opt.MapFrom(src => src.TransactionCurrencyId));
    }
}
