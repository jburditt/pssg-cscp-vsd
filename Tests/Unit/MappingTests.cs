public class MappingTests(IMapper mapper)
{
    [Fact]
    public void Map_Invoice_Entity_To_Dto()
    {
        // Arrange
        var invoiceEntity = new Vsd_Invoice();
        invoiceEntity.Id = Guid.NewGuid();
        invoiceEntity.StateCode = Vsd_Invoice_StateCode.Active;
        invoiceEntity.StatusCode = Vsd_Invoice_StatusCode.Draft;
        invoiceEntity.OwnerId = new EntityReference("systemuser", Guid.NewGuid());
        invoiceEntity.Vsd_Payee = new EntityReference("contact", Guid.NewGuid());
        invoiceEntity.Vsd_Cvap_SToBid = new EntityReference("not sure what this should be", new Guid("6baad5a2-7120-eb11-b821-00505683fbf4"));

        // Act
        var invoice = mapper.Map<Invoice>(invoiceEntity);

        // Assert
        Assert.NotNull(invoice);
        Assert.Equal(invoice.CvapStobId, invoiceEntity.Vsd_Cvap_SToBid.Id);
    }
}
