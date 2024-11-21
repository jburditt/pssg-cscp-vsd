namespace Resources;

public class IncomeSupportParameterMapper : Profile
{
    public IncomeSupportParameterMapper()
    {
        CreateMap<IncomeSupportParameter, Vsd_IncomeSupportParameter>()
            .ForMember(dest => dest.Vsd_Type, opts => opts.MapFrom(src => src.Type))
            .ForMember(dest => dest.Vsd_EffectiveDate, opts => opts.MapFrom(src => src.EffectiveDate))
            .ForMember(dest => dest.StateCode, opts => opts.MapFrom(src => src.StateCode))
            .ForMember(dest => dest.StatusCode, opts => opts.MapFrom(src => src.StatusCode))
            .ForMember(dest => dest.Vsd_IncomeSupportParameterValidated, opts => opts.MapFrom(src => src.Validated));
        ;
    }
}
