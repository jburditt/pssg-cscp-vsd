namespace Resources;

public class ConfigurationMapper : Profile
{
    public ConfigurationMapper()
    {
        CreateMap<Vsd_Config, Configuration>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StateCode, opt => opt.MapFrom(src => src.StateCode))
            .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Vsd_Group))
            .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Vsd_Key))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Vsd_Value))
            .ForMember(dest => dest.ProgramUnit, opt => opt.MapFrom(src => src.Vsd_ProgramUnit));

        CreateMap<Configuration, Vsd_Config>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StateCode, opt => opt.MapFrom(src => src.StateCode))
            .ForMember(dest => dest.Vsd_Group, opt => opt.MapFrom(src => src.Group))
            .ForMember(dest => dest.Vsd_Key, opt => opt.MapFrom(src => src.Key))
            .ForMember(dest => dest.Vsd_Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.Vsd_ProgramUnit, opt => opt.MapFrom(src => src.ProgramUnit));
    }
}

