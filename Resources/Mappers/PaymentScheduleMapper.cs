using static Resources.PaymentScheduleRepository;

namespace Resources;

public class PaymentScheduleMapper : Profile
{
    public PaymentScheduleMapper()
    {
        CreateMap<Vsd_PaymentSchedule, PaymentSchedule>()
            .ForMember(dest => dest.EntitlementId, opts => opts.MapFrom(src => src.Vsd_EntitlementId.Id))
            .ForMember(dest => dest.FirstRunDate, opts => opts.MapFrom(src => src.Vsd_FirstRunDate))
            .ForMember(dest => dest.Frequency, opts => opts.MapFrom(src => src.Vsd_Frequency))
            .ForMember(dest => dest.NextRunDate, opts => opts.MapFrom(src => src.Vsd_NextRUndate))
            .ForMember(dest => dest.XValue, opts => opts.MapFrom(src => src.Vsd_XValue))
            .ForMember(dest => dest.PercentageDeduction, opts => opts.MapFrom(src => src.Vsd_PercentagedEduction))
            .ForMember(dest => dest.ShareOptions, opts => opts.MapFrom(src => src.Vsd_ShareOptions))
            .ForMember(dest => dest.ShareValue, opts => opts.MapFrom(src => src.Vsd_ShareValue))
            .ForMember(dest => dest.CppDeduction, opts => opts.MapFrom(src => src.Vsd_CPpDeduction))
            .ForMember(dest => dest.OtherDeduction, opts => opts.MapFrom(src => src.Vsd_OtherDeduction))
            .ForMember(dest => dest.OverPaymentEmi, opts => opts.MapFrom(src => src.Vsd_OverpayMenteMi))
            .ForMember(dest => dest.OverPaymentAmount, opts => opts.MapFrom(src => src.Vsd_OverpaymentAmount));

        CreateMap<PaymentSchedule, Vsd_PaymentSchedule>()
            .ForMember(dest => dest.StateCode, opts => opts.MapFrom(src => (Vsd_PaymentSchedule_StateCode)src.StateCode))
            .ForMember(dest => dest.Vsd_FirstRunDate, opts => opts.MapFrom(src => src.FirstRunDate))
            .ForMember(dest => dest.Vsd_NextRUndate, opts => opts.MapFrom(src => src.NextRunDate))
            .ForMember(dest => dest.Vsd_Frequency, opts => opts.MapFrom(src => (Vsd_PaymentSchedule_Vsd_Frequency?)src.Frequency))
            .ForMember(dest => dest.Vsd_XValue, opts => opts.MapFrom(src => src.XValue))
            .ForMember(dest => dest.Vsd_PercentagedEduction, opts => opts.MapFrom(src => src.PercentageDeduction))
            .ForMember(dest => dest.Vsd_ShareOptions, opts => opts.MapFrom(src => src.ShareOptions))
            .ForMember(dest => dest.Vsd_ShareValue, opts => opts.MapFrom(src => src.ShareValue))
            .ForMember(dest => dest.Vsd_CPpDeduction, opts => opts.MapFrom(src => src.CppDeduction))
            .ForMember(dest => dest.Vsd_OtherDeduction, opts => opts.MapFrom(src => src.OtherDeduction))
            .ForMember(dest => dest.Vsd_OverpayMenteMi, opts => opts.MapFrom(src => src.OverPaymentEmi))
            .ForMember(dest => dest.Vsd_OverpaymentAmount, opts => opts.MapFrom(src => src.OverPaymentAmount));


        CreateMap<PaymentScheduleComposite, PaymentScheduleResult>();
    }
}
