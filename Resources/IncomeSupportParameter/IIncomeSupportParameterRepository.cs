namespace Resources;

public interface IIncomeSupportParameterRepository
{
    IncomeSupportParameter Single(BaseIncomeSupportParameterQuery query);
    decimal GetCOLA(DateTime effectiveDate, decimal cap);
}
