namespace Resources;

public interface IIncomeSupportParameterRepository
{
    decimal GetCOLA(DateTime effectiveDate, decimal cap);
}
