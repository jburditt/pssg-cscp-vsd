namespace Resources;

public class InvoiceLineDetailMapper : Profile
{
    public InvoiceLineDetailMapper()
    {
        CreateMap<Vsd_InvoiceLineDetail, InvoiceLineDetail>()
            .ForMember(dest => dest.Approved, opts => opts.MapFrom(src => src.Vsd_LineItemApproved))
            .ForMember(dest => dest.InvoiceType, opts => opts.MapFrom(src => (InvoiceType?)src.Vsd_InvoiceType))
            .ForMember(dest => dest.AmountSimple, opts => opts.MapFrom(src => src.Vsd_AmountSimple))
            .ForMember(dest => dest.ProgramUnit, opts => opts.MapFrom(src => src.Vsd_ProgramUnit))
            .ForMember(dest => dest.TaxExemption, opts => opts.MapFrom(src => src.Vsd_TaxExemption))
            .ForMember(dest => dest.InvoiceId, opts => opts.MapFrom(src => src.Vsd_InvoiceId.Id))
            .ForMember(dest => dest.Owner, opts => opts.MapFrom(src => src.OwnerId))
            .ForMember(dest => dest.ProvinceStateId, opts => opts.MapFrom(src => src.Vsd_ProvinceStateId.Id))
            .ForMember(dest => dest.CurrencyId, opts => opts.MapFrom(src => src.TransactionCurrencyId.Id));

        CreateMap<InvoiceLineDetail, Vsd_InvoiceLineDetail>()
            .ForMember(dest => dest.Vsd_LineItemApproved, opts => opts.MapFrom(src => src.Approved))
            .ForMember(dest => dest.Vsd_InvoiceType, opts => opts.MapFrom(src => (Vsd_InvoiceTypes?)src.InvoiceType))
            .ForMember(dest => dest.Vsd_AmountSimple, opts => opts.MapFrom(src => src.AmountSimple))
            .ForMember(dest => dest.Vsd_ProgramUnit, opts => opts.MapFrom(src => src.ProgramUnit))
            .ForMember(dest => dest.Vsd_TaxExemption, opts => opts.MapFrom(src => src.TaxExemption))
            .ForMember(dest => dest.Vsd_InvoiceId, opts => opts.MapFrom(src => new EntityReference(Vsd_Invoice.EntityLogicalName, src.InvoiceId)))
            .ForMember(dest => dest.OwnerId, opts => opts.MapFrom(src => src.Owner))
            .ForMember(dest => dest.Vsd_ProvinceStateId, opts => opts.MapFrom(src => src.ProvinceStateId != null ? new EntityReference(Vsd_Province.EntityLogicalName, src.ProvinceStateId.Value) : null))
            .ForMember(dest => dest.TransactionCurrencyId, opts => opts.MapFrom(src => new EntityReference(TransactionCurrency.EntityLogicalName, src.CurrencyId)));
    }
}
