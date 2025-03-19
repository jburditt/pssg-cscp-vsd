namespace Resources;

public class ContractRepository : BaseRepository<Vsd_Contract, Contract>, IContractRepository
{
    private readonly DatabaseContext _databaseContext;

    public ContractRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper) 
    {
        _databaseContext = databaseContext;
    }

    public Contract FirstOrDefault(FindContractQuery contractQuery)
    {
        var queryResults = _databaseContext.Vsd_ContractSet
            .WhereIf(contractQuery.Id != null, x => x.Id == contractQuery.Id)
            .FirstOrDefault();

        var contract = _mapper.Map<Contract>(queryResults);

        // if there is a customer, check if the customer is a reference to an account or contact, and load the corresponding method of payment from the referenced entity
        if (queryResults?.Vsd_Customer != null)
        {
            var customerEntityReferenceName = queryResults.Vsd_Customer.LogicalName;
            if (customerEntityReferenceName == Database.Model.Account.EntityLogicalName)
            {
                contract.MethodOfPayment = (MethodOfPayment?)_databaseContext.AccountSet.FirstOrDefault(p => p.Id == queryResults.Vsd_Customer.Id)?.Vsd_MethodOfPayment;
            }
            else if (customerEntityReferenceName == Database.Model.Contact.EntityLogicalName)
            {
                contract.MethodOfPayment = (MethodOfPayment?)_databaseContext.ContactSet.FirstOrDefault(p => p.Id == queryResults.Vsd_Customer.Id)?.Vsd_MethodOfPayment;
            }
        }

        return contract;
    }

    public IEnumerable<Contract> Query(ContractQuery contractQuery)
    {
        var queryResults = _databaseContext.Vsd_ContractSet
            .WhereIf(contractQuery.Id != null, x => x.Id == contractQuery.Id)
            .WhereIf(contractQuery.StateCode != null, x => x.StateCode == (Vsd_Contract_StateCode?)contractQuery.StateCode)
            .WhereIf(contractQuery.StatusCode != null, x => x.StatusCode == (Vsd_Contract_StatusCode?)contractQuery.StatusCode)
            .WhereIf(contractQuery.NotNullCustomer != null, x => x.Vsd_Customer != null)
            .WhereIf(contractQuery.NotNullFiscalStartDate != null, x => x.Vsd_FiscalStartDate != null)
            .WhereIf(contractQuery.NotNullFiscalEndDate != null, x => x.Vsd_FiscalEndDate != null)
            .WhereIf(contractQuery.NotEqualType != null, x => x.Vsd_Type != (Vsd_ContractType?)contractQuery.NotEqualType)
            .WhereIf(contractQuery.CpuCloneFlag != null, x => x.Vsd_CpuCloneFlag == contractQuery.CpuCloneFlag)
            .ToList();
        return _mapper.Map<IEnumerable<Contract>>(queryResults);
    }

    public bool IsCloned(Guid id)
    {
        var entity = _databaseContext.Vsd_ContractSet.FirstOrDefault(x => x.Vsd_ClonedContractId.Id == id);
        return entity != null;
    }

    public Guid? Clone(Guid id)
    {
        var entity = _databaseContext.Vsd_ContractSet.First(x => x.Id == id);
        //_databaseContext.Detach(entity);
        //// deep clone entity
        //var clonedEntity = _mapper.Map<Vsd_Contract>(entity);
        //clonedEntity.EntityState = EntityState.Created;
        //_databaseContext.AddObject(clonedEntity);
        //_databaseContext.Detach(clonedEntity);

        //entity.EntityState = EntityState.Unchanged;
        //_databaseContext.Attach(entity);
        //entity.Vsd_ClonedContractId = new EntityReference(Vsd_Contract.EntityLogicalName, clonedEntity.Id);
        //_databaseContext.UpdateObject(entity);

        //_databaseContext.SaveChanges();
        //return clonedEntity.Id;

        var request = new Vsd_CloneContractRequest();
        request.RequestName = Vsd_CloneContractRequest.ActionLogicalName;
        request.Target = entity.ToEntityReference();
        var response = (Vsd_CloneContractResponse)_databaseContext.Execute(request);
        if (response.IsSuccess)
        {
            return new Guid(response.Result);
        }
        else
        {
            return null;
        }
    }

    // NOTE only used for testing
    public bool DeleteClone(Guid id)
    {
        var clonedEntity = _databaseContext.Vsd_ContractSet.First(x => x.Vsd_ClonedContractId.Id == id);
        Delete(clonedEntity.Id);

        //var entity = _databaseContext.Vsd_ContractSet.First(x => x.Id == id);
        //entity.Vsd_ClonedContractId = null;
        //entity.Vsd_CpuCloneFlag = true;
        //return Update(entity);
        return true;
    }
}
