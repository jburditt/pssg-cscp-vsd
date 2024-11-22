namespace Manager;

public class IncomeSupportParameterHandlers(IIncomeSupportParameterRepository repository, IMapper mapper) :
    IRequestHandler<SingleIncomeSupportParameterQuery, IncomeSupportParameter>
{
    public async Task<IncomeSupportParameter> Handle(SingleIncomeSupportParameterQuery query, CancellationToken cancellationToken)
    {
        var entity = repository.Single(query);
        var dto = mapper.Map<IncomeSupportParameter>(entity);
        return await Task.FromResult(dto);
    }
}
