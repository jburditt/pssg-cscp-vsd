namespace Resources;

public class EntitlementMapper : Profile
{
    public EntitlementMapper()
    {
        CreateMap<Vsd_Entitlement, Entitlement>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Vsd_EntitlementId))
            .ForMember(dest => dest.FinanciallyDependentIfmWage, opts => opts.MapFrom(src => src.Vsd_FinanciallyDependentIfMWage))
            .ForMember(dest => dest.SetCap, opts => opts.MapFrom(src => src.Vsd_SetCap))
            .ForMember(dest => dest.BenefitCategoryId, opts => opts.MapFrom(src => src.Vsd_BenefitCategoryId.Id))
            .ForMember(dest => dest.BenefitSubTypeId, opts => opts.MapFrom(src => src.Vsd_BenefitSubtypeId.Id))
            .ForMember(dest => dest.BenefitSubTypeName, opts => opts.MapFrom(src => src.Vsd_BenefitSubtypeIdName))
            .ForMember(dest => dest.BenefitTypeId, opts => opts.MapFrom(src => src.Vsd_BenefitTypeId.Id))
            .ForMember(dest => dest.TaxExemptFlag, opts => opts.MapFrom(src => src.Vsd_TaxExemptFlag))
            .ForMember(dest => dest.CvapAvailableEntitilement, opts => opts.MapFrom(src => src.Vsd_Cvap_Available_Entitlement))
            .ForMember(dest => dest.EffectiveDate, opts => opts.MapFrom(src => src.Vsd_EffectiveDate));
    }
}
