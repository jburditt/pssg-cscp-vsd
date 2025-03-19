namespace Resources;

public class ProvinceMapper : Profile
{
    public ProvinceMapper()
    {
        CreateMap<Vsd_Province, Province>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StateCode, opt => opt.MapFrom(src => src.StateCode))
            .ForMember(dest => dest.TaxRate, opt => opt.MapFrom(src => src.Vsd_TaxRate))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Vsd_Code));
    }
}
