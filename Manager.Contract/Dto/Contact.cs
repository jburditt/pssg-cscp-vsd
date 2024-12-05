public record FindContactQuery : BaseContactQuery, IRequest<Contact> { }
public record ContactQuery : BaseContactQuery, IRequest<IEnumerable<Contact>> { }
public record BaseContactQuery
{
    public Guid? Id { get; set; }
}

public record Contact : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public string? FirstName { get; set; }              // Dynamics Business Recommended
    public required string LastName { get; set; }       // Dynamics Business Required
    public string? AccountNumber { get; set; }          // Dynamics Optional
    public required string ContactRole { get; set; }    // Dynamics Business Required
    public int? SupplierSiteNumber { get; set; }        // Dynamics Optional
    public string? RestChequeName { get; set; }         // Dynamics Optional
    public Address[]? Addresses { get; set; }           // Dynamics Business Recommended 'address1_line1'    
}