
namespace Manager;

public class CasPaymentHandlers(ICasPaymentRepository repository, IMapper mapper) : FindQueryBaseHandlers<ICasPaymentRepository, CasPayment, FindCasPaymentQuery, CasPaymentQuery>(repository)
{

}
