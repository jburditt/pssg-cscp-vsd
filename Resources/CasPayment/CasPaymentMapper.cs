namespace Resources;

public class CasPaymentMapper : Profile
{
    public CasPaymentMapper()
    {
        CreateMap<Vsd_CasPaymentType, CasPayment>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StateCode, opt => opt.MapFrom(src => src.StateCode))
            .ForMember(dest => dest.ClientCode, opt => opt.MapFrom(src => src.Vsd_ClientCode))
            .ForMember(dest => dest.ProjectCode, opt => opt.MapFrom(src => src.Vsd_ProjectCode))
            .ForMember(dest => dest.ResponsibilityCentre, opt => opt.MapFrom(src => src.Vsd_ResponsibilityCentre))
            .ForMember(dest => dest.ServiceLine, opt => opt.MapFrom(src => src.Vsd_ServiceLine))
            .ForMember(dest => dest.Stob, opt => opt.MapFrom(src => src.Vsd_SToB));
    }
}
