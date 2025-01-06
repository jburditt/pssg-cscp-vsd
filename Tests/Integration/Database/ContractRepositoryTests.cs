public class ContractRepositoryTests(IContractRepository repository)
{
    // WARNING!!! these are not reliable tests, they will fail, these were shortcuts I used for building a POC, these tests will need to be adjusted in order to be idempotent
    
    [Fact]
    public void Insert()
    {
        // Arrange
        var contract = FakeData.Contracts[0];

        // Act
        var id = repository.Insert(contract);

        // Assert
        Assert.True(id != Guid.Empty);
    }

    [Fact]
    public void Upsert()
    {
        // Arrange
        var contract = FakeData.Contracts[0];

        // Act
        var id = repository.Upsert(contract);

        // Assert
        Assert.True(id != Guid.Empty);
    }

    [Fact]
    public void Query()
    {
        // Arrange
        var command = new ContractQuery();

        // Act
        var result = repository.Query(command);

        // Assert
        Assert.True(result.Count() > 0);
    }

    [Fact]
    public void Delete()
    {
        // Arrange
        var id = new Guid("0fe87b88-a7d3-eb11-b828-00505683fbf4\r\n");

        // Act
        var result = repository.TryDelete(id);

        // Assert
        Assert.True(result);
    }

    // FINDINGS
    // Cloning using the vsd_CloneContract Action does not duplicate all fields like Dynamics scheduled job does
    // Cannot save vsd_contract entity with "DulyExecuted" status code
    // Scheduled Job worked the first time and then stopped working, no clone was found and vsd_ClonedContractId was null
    [Fact]
    public void Clone()
    {
        // Arrange
        var command = new ContractQuery();
        command.StateCode = StateCode.Active;
        command.StatusCode = ContractStatusCode.DulyExecuted;
        command.CpuCloneFlag = true;

        // Act
        var result = repository.Query(command);
        Guid? id = null;
        foreach (var contract in result)
        {
            if (!repository.IsCloned(contract.Id))
            {
                id = repository.Clone(contract.Id);
            }
        }

        // Assert
        Assert.NotNull(id);
    }

    [Fact]
    public void Delete_Clones()
    {
        var query = new ContractQuery();
        query.StateCode = StateCode.Active;
        query.StatusCode = ContractStatusCode.DulyExecuted;
        query.CpuCloneFlag = true;
        var result = repository.Query(query);

        List<Guid> ids = new List<Guid>();
        foreach (var contract in result)
        {
            // if cloned
            if (repository.IsCloned(contract.Id))
            {
                // delete the clone
                repository.DeleteClone(contract.Id);
            }
        }
    }
}
