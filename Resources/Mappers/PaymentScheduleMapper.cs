using static Resources.PaymentScheduleRepository;

namespace Resources;

public class PaymentScheduleMapper : Profile
{
    public PaymentScheduleMapper()
    {
        CreateMap<Vsd_PaymentSchedule, PaymentSchedule>();

        CreateMap<PaymentScheduleComposite, PaymentScheduleResult>();
    }
}
