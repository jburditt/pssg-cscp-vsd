using static Resources.PaymentScheduleRepository;

namespace Resources;

public class PaymentScheduleMapper : Profile
{
    public PaymentScheduleMapper()
    {
        CreateMap<Vsd_PaymentSchedule, PaymentSchedule>()
            .ForMember(dest => dest.StateCode, opts => opts.MapFrom(src => (StateCode?)src.StateCode))
            .ForMember(dest => dest.EntitlementId, opts => opts.MapFrom(src => src.Vsd_EntitlementId.Id))
            .ForMember(dest => dest.FirstRunDate, opts => opts.MapFrom(src => src.Vsd_FirstRunDate))
            .ForMember(dest => dest.Frequency, opts => opts.MapFrom(src => src.Vsd_Frequency))
            .ForMember(dest => dest.NextRunDate, opts => opts.MapFrom(src => src.Vsd_NextRUndate))
            .ForMember(dest => dest.XValue, opts => opts.MapFrom(src => src.Vsd_XValue))
            .ForMember(dest => dest.PercentageDeduction, opts => opts.MapFrom(src => src.Vsd_PercentagedEduction))
            .ForMember(dest => dest.ShareOptions, opts => opts.MapFrom(src => src.Vsd_ShareOptions))
            .ForMember(dest => dest.ShareValue, opts => opts.MapFrom(src => src.Vsd_ShareValue))
            .ForMember(dest => dest.CppDeduction, opts => opts.MapFrom(src => src.Vsd_CPpDeduction))
            .ForMember(dest => dest.OtherDeduction, opts => opts.MapFrom(src => src.Vsd_OtherDeduction))
            .ForMember(dest => dest.OverPaymentEmi, opts => opts.MapFrom(src => src.Vsd_OverpayMenteMi))
            .ForMember(dest => dest.OverPaymentAmount, opts => opts.MapFrom(src => src.Vsd_OverpaymentAmount))
            .ForMember(dest => dest.CaseId, opts => opts.MapFrom(src => src.Vsd_CaseId.Id))
            .ForMember(dest => dest.CaseName, opts => opts.MapFrom(src => src.Vsd_CaseiDnaMe))
            .ForMember(dest => dest.Payee, opts => opts.MapFrom(src => src.Vsd_Payee))
            .ForMember(dest => dest.StatusCode, opts => opts.MapFrom(src => (PaymentScheduleStatusCode?)src.StatusCode))
            .ForMember(dest => dest.TotalAmountOfIncomeSupport, opts => opts.MapFrom(src => src.Vsd_TotalAmountOfIncomeSupport))
            .ForMember(dest => dest.RemainingPaymentAmount, opts => opts.MapFrom(src => src.Vsd_RemainingPaymentAmount))
            .ForMember(dest => dest.ActualValue, opts => opts.MapFrom(src => src.Vsd_ActualValue));

        CreateMap<PaymentSchedule, Vsd_PaymentSchedule>()
            .ForMember(dest => dest.StateCode, opts => opts.MapFrom(src => (Vsd_PaymentSchedule_StateCode)src.StateCode))
            .ForMember(dest => dest.Vsd_FirstRunDate, opts => opts.MapFrom(src => src.FirstRunDate))
            .ForMember(dest => dest.Vsd_NextRUndate, opts => opts.MapFrom(src => src.NextRunDate))
            .ForMember(dest => dest.Vsd_Frequency, opts => opts.MapFrom(src => (Vsd_PaymentSchedule_Vsd_Frequency?)src.Frequency))
            .ForMember(dest => dest.Vsd_XValue, opts => opts.MapFrom(src => src.XValue))
            .ForMember(dest => dest.Vsd_PercentagedEduction, opts => opts.MapFrom(src => src.PercentageDeduction))
            .ForMember(dest => dest.Vsd_ShareOptions, opts => opts.MapFrom(src => src.ShareOptions))
            .ForMember(dest => dest.Vsd_ShareValue, opts => opts.MapFrom(src => src.ShareValue))
            .ForMember(dest => dest.Vsd_CPpDeduction, opts => opts.MapFrom(src => src.CppDeduction))
            .ForMember(dest => dest.Vsd_OtherDeduction, opts => opts.MapFrom(src => src.OtherDeduction))
            .ForMember(dest => dest.Vsd_OverpayMenteMi, opts => opts.MapFrom(src => src.OverPaymentEmi))
            .ForMember(dest => dest.Vsd_OverpaymentAmount, opts => opts.MapFrom(src => src.OverPaymentAmount))
            .ForMember(dest => dest.Vsd_CaseId, opts => opts.MapFrom(src => new EntityReference("incident", src.CaseId)))
            .ForMember(dest => dest.Vsd_CaseiDnaMe, opts => opts.MapFrom(src => src.CaseName))
            .ForMember(dest => dest.Vsd_Payee, opts => opts.MapFrom(src => src.Payee))
            .ForMember(dest => dest.StatusCode, opts => opts.MapFrom(src => (Vsd_PaymentSchedule_StatusCode?)src.StatusCode))
            .ForMember(dest => dest.Vsd_TotalAmountOfIncomeSupport, opts => opts.MapFrom(src => src.TotalAmountOfIncomeSupport))
            .ForMember(dest => dest.Vsd_RemainingPaymentAmount, opts => opts.MapFrom(src => src.RemainingPaymentAmount))
            .ForMember(dest => dest.Vsd_ActualValue, opts => opts.MapFrom(src => src.ActualValue));

        CreateMap<PaymentScheduleComposite, PaymentScheduleEntitlement>();
    }
}
