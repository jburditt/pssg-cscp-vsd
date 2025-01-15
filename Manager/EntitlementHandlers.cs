namespace Manager;

public class EntitlementHandlers(IEntitlementRepository repository) : 
    IRequestHandler<UpdatePaymentScheduleStatus, bool>
{
    public async Task<bool> Handle(UpdatePaymentScheduleStatus command, CancellationToken token)
    {
        var result = repository.UpdatePaymentScheduleStatus(command.Id, command.PaymentScheduleStatus);
        return await Task.FromResult(result);
    }
}
