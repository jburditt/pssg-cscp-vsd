using Newtonsoft.Json;

public class InvoiceRepositoryTests(IInvoiceRepository repository)
{
    // WARNING!!! these are not reliable tests, they will fail, these were shortcuts I used for building a POC, these tests will need to be adjusted in order to be idempotent

    [Fact]
    public void Query()
    {
        // Arrange
        var command = new InvoiceQuery();

        // Act
        var result = repository.Query(command);

        var test = JsonConvert.SerializeObject(result.First());

        // Assert
        Assert.True(result.Count() > 0);
    }

    [Fact]
    public void Update()
    {
        // Arrange
        var invoice = new Invoice();

        // Act
        var result = repository.Update(invoice);

        // Assert
        //Assert.True(result != Guid.Empty);
    }
}
