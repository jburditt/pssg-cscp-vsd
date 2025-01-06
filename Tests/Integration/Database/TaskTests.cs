using Newtonsoft.Json;

public class TaskTests(ITaskRepository repository)
{
    // WARNING!!! these are not reliable tests, they will fail, these were shortcuts I used for building a POC, these tests will need to be adjusted in order to be idempotent

    [Fact]
    public void Query()
    {
        // Arrange
        var id = new Guid("f1dfc199-ae8c-ef11-8e06-b07d6486ef10");

        // Act
        var query = new TaskQuery();
        query.Id = id;
        var result = repository.Query(query);

        var test = JsonConvert.SerializeObject(result.Tasks);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Delete()
    {
        // Arrange
        var id = new Guid("bb961ae5-a88c-ef11-b84f-005056830319");

        // Act
        var result = repository.TryDelete(id);
        
        // Assert
        Assert.True(result);
    }
}
