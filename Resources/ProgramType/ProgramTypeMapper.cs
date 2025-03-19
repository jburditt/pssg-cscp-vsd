namespace Resources;

public class ProgramTypeMapper : Profile
{
    public ProgramTypeMapper()
    {
        CreateMap<Vsd_ProgramType, ProgramType>()
            .ForMember(dest => dest.ClientCode, opts => opts.MapFrom(src => src.Vsd_ClientCode))
            .ForMember(dest => dest.ServiceLine, opts => opts.MapFrom(src => src.Vsd_ServiceLine))
            .ForMember(dest => dest.Stob, opts => opts.MapFrom(src => src.Vsd_SToB))
            .ForMember(dest => dest.ResponsibilityCentre, opts => opts.MapFrom(src => src.Vsd_ResponsibilityCentre))
            .ForMember(dest => dest.ProjectCode, opts => opts.MapFrom(src => src.Vsd_ProjectCode));

        CreateMap<ProgramType, Vsd_ProgramType>()
            .ForMember(dest => dest.Vsd_ClientCode, opts => opts.MapFrom(src => src.ClientCode))
            .ForMember(dest => dest.Vsd_ServiceLine, opts => opts.MapFrom(src => src.ServiceLine))
            .ForMember(dest => dest.Vsd_SToB, opts => opts.MapFrom(src => src.Stob))
            .ForMember(dest => dest.Vsd_ResponsibilityCentre, opts => opts.MapFrom(src => src.ResponsibilityCentre))
            .ForMember(dest => dest.Vsd_ProjectCode, opts => opts.MapFrom(src => src.ProjectCode));

        //CreateMap<StateCode, Vsd_ProgramType_StateCode>();
    }
}
