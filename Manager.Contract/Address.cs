public record Address
(
    string? AddressLine1,           
    string? AddressLine2,           
    string? AddressLine3,           
    string? City,                   
    string? StateOrProvince,
    string? PostalCode
) {
    public string? Country { get; set; }
}