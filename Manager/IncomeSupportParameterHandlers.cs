namespace Manager;

public class IncomeSupportParameterHandlers(IIncomeSupportParameterRepository repository, IMapper mapper) :
    IRequestHandler<SingleIncomeSupportParameterQuery, IncomeSupportParameter>
{
    public async Task<IncomeSupportParameter> Handle(SingleIncomeSupportParameterQuery query, CancellationToken cancellationToken)
    {
        var dto = repository.Single(query);
        return await Task.FromResult(dto);
    }
}
