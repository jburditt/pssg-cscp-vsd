public enum AddressCode
{
    AlternateAddress = 100000000,
    MailingAddress = 1,
    Other = 4,
    PaymentAddress = 2,
    PreviousMailingAddress = 3,
}

public record Address
(
    AddressCode? _AddressCode,
    string? AddressLine1,           
    string? AddressLine2,           
    string? AddressLine3,           
    string? City,                   
    string? StateOrProvince,
    string? PostalCode
) {
    public static AddressCode? MapAddress1Code(int? addressCode) => addressCode switch
    {
        1 => AddressCode.MailingAddress,
        2 => AddressCode.PaymentAddress,
        3 => AddressCode.PreviousMailingAddress,
        4 => AddressCode.Other,
        100000000 => AddressCode.AlternateAddress,
        null => null
    };

    public static AddressCode? MapAddress2Code(int? addressCode) => addressCode switch
    {
        1 => AddressCode.MailingAddress,
        100000001 => AddressCode.PaymentAddress,
        100000000 => AddressCode.PreviousMailingAddress,
        100000002 => AddressCode.Other,
        100000003 => AddressCode.AlternateAddress,
        null => null
    };
}