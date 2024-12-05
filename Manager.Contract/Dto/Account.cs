public record FindAccountQuery : BaseAccountQuery, IRequest<Account> { }
public record AccountQuery : BaseAccountQuery, IRequest<IEnumerable<Account>> { }
public record BaseAccountQuery
{
    public Guid? Id { get; set; }
}

public record Account : IDto
{
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    public string? Name { get; set; }                   
    public string? AccountNumber { get; set; }          
    public string? SupplierSiteNumber { get; set; }     
    public string? RestChequeName { get; set; }         
    public Address[]? Addresses { get; set; }            
}