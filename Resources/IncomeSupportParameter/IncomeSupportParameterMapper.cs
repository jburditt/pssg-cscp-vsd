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
            .ForMember(dest => dest.Vsd_IncomeSupportParameterValidated, opts => opts.MapFrom(src => src.Validated))
            .ForMember(dest => dest.Vsd_Value, opts => opts.MapFrom(src => src.Value));

        CreateMap<Vsd_IncomeSupportParameter, IncomeSupportParameter>()
            .ForMember(dest => dest.Type, opts => opts.MapFrom(src => (IncomeSupportParameterType?)src.Vsd_Type))
            .ForMember(dest => dest.EffectiveDate, opts => opts.MapFrom(src => src.Vsd_EffectiveDate))
            .ForMember(dest => dest.StateCode, opts => opts.MapFrom(src => (StateCode?)src.StateCode))
            .ForMember(dest => dest.StatusCode, opts => opts.MapFrom(src => (IncomeSupportParameterStatusCode?)src.StatusCode))
            .ForMember(dest => dest.Validated, opts => opts.MapFrom(src => (YesNo?)src.Vsd_IncomeSupportParameterValidated))
            .ForMember(dest => dest.Value, opts => opts.MapFrom(src => src.Vsd_Value));
    }
}
