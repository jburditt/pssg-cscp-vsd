public class CountryMapper : Profile
{
    public CountryMapper()
    {
        CreateMap<Vsd_Country, Country>()
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Vsd_Code))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Vsd_Name));

        CreateMap<Country, Vsd_Country>()
            .ForMember(dest => dest.Vsd_Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.Vsd_Name, opt => opt.MapFrom(src => src.Name));
    }
}