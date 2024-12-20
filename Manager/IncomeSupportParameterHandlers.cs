namespace Manager;

public class IncomeSupportParameterHandlers(IIncomeSupportParameterRepository repository, IMapper mapper) :
    IRequestHandler<SingleIncomeSupportParameterQuery, IncomeSupportParameter>,
    IRequestHandler<GetColaCommand, decimal>
{
    public async Task<IncomeSupportParameter> Handle(SingleIncomeSupportParameterQuery query, CancellationToken cancellationToken)
    {
        var dto = repository.Single(query);
        return await Task.FromResult(dto);
    }

    public async Task<decimal> Handle(GetColaCommand command, CancellationToken cancellationToken)
    {
        var result = repository.GetCOLA(command.EffectiveDate, command.Cap);
        return await Task.FromResult(result);
    }
}
