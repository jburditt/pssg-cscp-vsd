public enum AccountAddress1Code
{
    AlternateAddress = 100000000,
    MailingAddress = 1,
    Other = 4,
    PaymentAddress = 2,
    PreviousMailingAddress = 3,
}

public enum AccountAddress2Code
{
    AlternateAddress = 100000003,
    MailingAddress = 1,
    Other = 100000002,
    PaymentAddress = 100000001,
    PreviousMailingAddress = 100000000,
}

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
    public string? InstitutionNumber { get; set; }      
    public string? TransitNumber { get; set; }          
    public int? SupplierSiteNumber { get; set; }     
    public string? RestChequeName { get; set; }         
    public AccountAddress1Code? Address1Code { get; set; }
    public AccountAddress2Code? Address2Code { get; set; }
    public Address[]? Addresses { get; set; }
    public string[]? Emails { get; set; }
}