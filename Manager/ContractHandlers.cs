namespace Manager;

public class ContractHandlers : 
    FindQueryBaseHandlers<IContractRepository, Contract.Contract, FindContractQuery, ContractQuery>,
    IRequestHandler<ContractQuery, IEnumerable<Contract.Contract>>,
    IRequestHandler<FindContractQuery, Contract.Contract>,
    IRequestHandler<IsClonedCommand, bool>,
    IRequestHandler<CloneCommand, Guid?>
{
    public ContractHandlers(IContractRepository repository) : base(repository) { }

    // IsCloned
    public async Task<bool> Handle(IsClonedCommand command, CancellationToken cancellationToken)
    {
        var result = _repository.IsCloned(command.Id);
        return await Task.FromResult(result);
    }

    // Clone
    public async Task<Guid?> Handle(CloneCommand cloneCommand, CancellationToken cancellationToken)
    {
        var result = _repository.Clone(cloneCommand.Id);
        return await Task.FromResult(result);
    }
}
