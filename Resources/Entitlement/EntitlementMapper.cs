namespace Resources;

public class EntitlementMapper : Profile
{
    public EntitlementMapper()
    {
        CreateMap<Vsd_Entitlement, Entitlement>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Vsd_EntitlementId))
            .ForMember(dest => dest.StateCode, opts => opts.MapFrom(src => (StateCode?)src.StateCode))
            .ForMember(dest => dest.FinanciallyDependentIfmWage, opts => opts.MapFrom(src => src.Vsd_FinanciallyDependentIfMWage))
            .ForMember(dest => dest.SetCap, opts => opts.MapFrom(src => src.Vsd_SetCap))
            .ForMember(dest => dest.BenefitCategoryId, opts => opts.MapFrom(src => src.Vsd_BenefitCategoryId.Id))
            .ForMember(dest => dest.BenefitSubTypeId, opts => opts.MapFrom(src => src.Vsd_BenefitSubtypeId.Id))
            .ForMember(dest => dest.BenefitSubTypeName, opts => opts.MapFrom(src => src.Vsd_BenefitSubtypeIdName))
            .ForMember(dest => dest.BenefitTypeId, opts => opts.MapFrom(src => src.Vsd_BenefitTypeId.Id))
            .ForMember(dest => dest.TaxExemptFlag, opts => opts.MapFrom(src => src.Vsd_TaxExemptFlag))
            .ForMember(dest => dest.CvapAvailableEntitilement, opts => opts.MapFrom(src => src.Vsd_Cvap_Available_Entitlement))
            .ForMember(dest => dest.EffectiveDate, opts => opts.MapFrom(src => src.Vsd_EffectiveDate));

        CreateMap<Entitlement, Vsd_Entitlement>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.StateCode, opts => opts.MapFrom(src => (Vsd_Entitlement_StateCode)src.StateCode))
            .ForMember(dest => dest.Vsd_FinanciallyDependentIfMWage, opts => opts.MapFrom(src => src.FinanciallyDependentIfmWage))
            .ForMember(dest => dest.Vsd_SetCap, opts => opts.MapFrom(src => src.SetCap))
            //.ForMember(dest => dest.Vsd_BenefitCategoryId, opts => opts.MapFrom(src => new EntityReference(Vsd_Entitent.EntityLogicalName, src.BenefitCategoryId)))
            //.ForMember(dest => dest.Vsd_BenefitSubtypeId, opts => opts.MapFrom(src => src.BenefitSubTypeId != null ? new EntityReference(src.BenefitSubTypeId))
            //.ForMember(dest => dest.BenefitSubTypeName, opts => opts.MapFrom(src => src.Vsd_BenefitSubtypeIdName))
            //.ForMember(dest => dest.BenefitTypeId, opts => opts.MapFrom(src => src.Vsd_BenefitTypeId.Id))
            //.ForMember(dest => dest.TaxExemptFlag, opts => opts.MapFrom(src => src.Vsd_TaxExemptFlag))
            //.ForMember(dest => dest.CvapAvailableEntitilement, opts => opts.MapFrom(src => src.Vsd_Cvap_Available_Entitlement))
            //.ForMember(dest => dest.EffectiveDate, opts => opts.MapFrom(src => src.Vsd_EffectiveDate))
            ;
    }
}
