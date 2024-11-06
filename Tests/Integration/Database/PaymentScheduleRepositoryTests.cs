using Newtonsoft.Json;

public class PaymentScheduleRepositoryTests(IPaymentScheduleRepository repository)
{
    // WARNING!!! these are not reliable tests, they will fail, these were shortcuts I used for building a POC, these tests will need to be adjusted in order to be idempotent

    [Fact]
    public void Query()
    {
        // Arrange
        var command = new PaymentScheduleQuery();
        command.StateCode = StateCode.Active;
        command.BeforeStartDate = DateTime.Now.AddYears(-1);
        command.BeforeNextRunDate = DateTime.Now.AddYears(-1);
        command.NotNullCaseId = true;
        command.NotNullPayeeId = true;
        command.Status = PaymentScheduleStatus.Active;

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
        //var result = repository.Update(invoice);

        // Assert
        //Assert.True(result != Guid.Empty);
    }
}
