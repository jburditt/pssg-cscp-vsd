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
            .ForMember(dest => dest.XValue, opts => opts.MapFrom(src => src.Vsd_XValue))
            .ForMember(dest => dest.PercentageDeduction, opts => opts.MapFrom(src => src.Vsd_PercentagedEduction))
            .ForMember(dest => dest.ShareOptions, opts => opts.MapFrom(src => src.Vsd_ShareOptions))
            .ForMember(dest => dest.ShareValue, opts => opts.MapFrom(src => src.Vsd_ShareValue));

        CreateMap<PaymentScheduleComposite, PaymentScheduleResult>();
    }
}
