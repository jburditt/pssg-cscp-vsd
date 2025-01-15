namespace Resources;

public class EntitlementMapper : Profile
{
    public EntitlementMapper()
    {
        CreateMap<Vsd_Entitlement, Entitlement>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Vsd_EntitlementId))
            .ForMember(dest => dest.StateCode, opts => opts.MapFrom(src => (StateCode?)src.StateCode))
            .ForMember(dest => dest.StatusCode, opts => opts.MapFrom(src => (EntitlementStatusCode?)src.StatusCode))
            .ForMember(dest => dest.EntitlementStage, opts => opts.MapFrom(src => (EntitlementStage?)src.Vsd_EntitlementStage))
            .ForMember(dest => dest.FinanciallyDependentIfmWage, opts => opts.MapFrom(src => src.Vsd_FinanciallyDependentIfMWage))
            .ForMember(dest => dest.SetCap, opts => opts.MapFrom(src => src.Vsd_SetCap))
            .ForMember(dest => dest.BenefitCategoryId, opts => opts.MapFrom(src => src.Vsd_BenefitCategoryId.Id))
            .ForMember(dest => dest.BenefitSubTypeId, opts => opts.MapFrom(src => src.Vsd_BenefitSubtypeId.Id))
            .ForMember(dest => dest.BenefitSubTypeName, opts => opts.MapFrom(src => src.Vsd_BenefitSubtypeIdName))
            .ForMember(dest => dest.BenefitTypeId, opts => opts.MapFrom(src => src.Vsd_BenefitTypeId.Id))
            .ForMember(dest => dest.TaxExemptFlag, opts => opts.MapFrom(src => src.Vsd_TaxExemptFlag))
            .ForMember(dest => dest.CvapAvailableEntitilement, opts => opts.MapFrom(src => src.Vsd_Cvap_Available_Entitlement))
            .ForMember(dest => dest.EffectiveDate, opts => opts.MapFrom(src => src.Vsd_EffectiveDate))
            .ForMember(dest => dest.IsRecurring, opts => opts.MapFrom(src => src.Vsd_IsRecurring))
            .ForMember(dest => dest.Case, opts => opts.MapFrom(src => src.Vsd_CaseId))
            .ForMember(dest => dest.ApplicantType, opts => opts.MapFrom(src => src.Vsd_ApplicantType))
            .ForMember(dest => dest.PaymentScheduleStatus, opts => opts.MapFrom(src => src.Vsd_PaymentScheduleStatus));

        CreateMap<Entitlement, Vsd_Entitlement>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.StateCode, opts => opts.MapFrom(src => (Vsd_Entitlement_StateCode)src.StateCode))
            .ForMember(dest => dest.StatusCode, opts => opts.MapFrom(src => (Vsd_Entitlement_StatusCode?)src.StatusCode))
            .ForMember(dest => dest.Vsd_EntitlementStage, opts => opts.MapFrom(src => (Vsd_Entitlement_Vsd_EntitlementStage?)src.EntitlementStage))
            .ForMember(dest => dest.Vsd_FinanciallyDependentIfMWage, opts => opts.MapFrom(src => src.FinanciallyDependentIfmWage))
            .ForMember(dest => dest.Vsd_SetCap, opts => opts.MapFrom(src => src.SetCap))
            .ForMember(dest => dest.Vsd_BenefitCategoryId, opts => opts.MapFrom(src => new EntityReference("vsd_benefitcategory", src.BenefitCategoryId)))
            // TODO replace Guid with StaticReference and then use the commented out code below
            //.ForMember(dest => dest.Vsd_BenefitCategoryId, opts => opts.MapFrom(src => src.BenefitCategoryId))
            .ForMember(dest => dest.Vsd_BenefitSubtypeId, opts => opts.MapFrom(src => src.BenefitSubTypeId != null ? new EntityReference("vsd_benefitsubtype", src.BenefitSubTypeId.Value) : null))
            //.ForMember(dest => dest.Vsd_BenefitSubtypeId, opts => opts.MapFrom(src => src.BenefitSubTypeId))
            .ForMember(dest => dest.Vsd_BenefitSubtypeIdName, opts => opts.MapFrom(src => src.BenefitSubTypeName))
            .ForMember(dest => dest.Vsd_BenefitTypeId, opts => opts.MapFrom(src => src.BenefitTypeId != null ? new EntityReference("vsd_benefittype", src.BenefitTypeId.Value) : null))
            .ForMember(dest => dest.Vsd_TaxExemptFlag, opts => opts.MapFrom(src => src.TaxExemptFlag))
            .ForMember(dest => dest.Vsd_Cvap_Available_Entitlement, opts => opts.MapFrom(src => src.CvapAvailableEntitilement))
            .ForMember(dest => dest.Vsd_EffectiveDate, opts => opts.MapFrom(src => src.EffectiveDate))
            .ForMember(dest => dest.Vsd_IsRecurring, opts => opts.MapFrom(src => src.IsRecurring))
            .ForMember(dest => dest.Vsd_CaseId, opts => opts.MapFrom(src => src.Case))
            .ForMember(dest => dest.Vsd_ApplicantType, opts => opts.MapFrom(src => src.ApplicantType))
            .ForMember(dest => dest.Vsd_PaymentScheduleStatus, opts => opts.MapFrom(src => src.PaymentScheduleStatus));
    }
}
