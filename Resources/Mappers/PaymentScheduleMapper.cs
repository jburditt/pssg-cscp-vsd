using static Resources.PaymentScheduleRepository;

namespace Resources;

public class PaymentScheduleMapper : Profile
{
    public PaymentScheduleMapper()
    {
        CreateMap<Vsd_PaymentSchedule, PaymentSchedule>()
            .ForMember(dest => dest.EntitlementId, opts => opts.MapFrom(src => src.Vsd_EntitlementId.Id))
            .ForMember(dest => dest.FirstRunDate, opts => opts.MapFrom(src => src.Vsd_FirstRunDate));

        CreateMap<PaymentScheduleComposite, PaymentScheduleResult>();
    }
}
