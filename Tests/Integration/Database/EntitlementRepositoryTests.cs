public class EntitlementRepositoryTests(IEntitlementRepository repository)
{
    // WARNING!!! these are not reliable tests, they will fail, these were shortcuts I used for building a POC, these tests will need to be adjusted in order to be idempotent

    [Fact]
    public void Update()
    {
        // Arrange
        var dto = new Entitlement() { Case = null };
        dto.Id = new Guid("");
        dto.PaymentScheduleStatus = PaymentScheduleStatus.Pause;

        // Act
        var result = repository.Update(dto);

        // Assert
        Assert.True(result);
        //var query = new EntitlementQuery { Id = dto.Id };
        //var updatedDto = repository.FirstOrDefault(query);
    }

    [Fact]
    public async Task Find()
    {
        var dtos = repository.Where(x => x.StateCode == StateCode.Active);

        Assert.NotNull(dtos);
    }
}
