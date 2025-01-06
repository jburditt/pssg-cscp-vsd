namespace Resources;

public interface IContractRepository : IBaseRepository<Contract>, IFindRepository<FindContractQuery, Contract>, IQueryRepository<ContractQuery, Contract>
{
    bool IsCloned(Guid id);
    Guid? Clone(Guid id);
    bool DeleteClone(Guid id);
}