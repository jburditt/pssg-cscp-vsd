public class ContactMapper : Profile
{
    public ContactMapper()
    {
        CreateMap<Database.Model.Contact, Contact>()
            .ForMember(dest => dest.InstitutionNumber, opts => opts.MapFrom(src => src.Vsd_InstitutionNo))
            .ForMember(dest => dest.AccountNumber, opts => opts.MapFrom(src => src.Vsd_AccountNo))
            .ForMember(dest => dest.Address1Code, opts => opts.MapFrom(src => src.Address1_AddressTypeCode))
            .ForMember(dest => dest.Addresses, opts => opts.MapFrom(src => new Address[3] { 
                new Address(src.Address1_Line1, src.Address1_Line2, src.Address1_Line3, src.Address1_City, src.Address1_StateOrProvince, src.Address1_PostalCode),
                new Address(src.Address2_Line1, src.Address2_Line2, src.Address2_Line3, src.Address2_City, src.Address2_StateOrProvince, src.Address2_PostalCode),
                new Address(src.Address3_Line1, src.Address3_Line2, src.Address3_Line3, src.Address3_City, src.Address3_StateOrProvince, src.Address3_PostalCode),
            }))
            .ForMember(dest => dest.ContactRole, opts => opts.MapFrom(src => src.Vsd_ContactRole))
            .ForMember(dest => dest.Emails, opts => opts.MapFrom(src => new string[3] { src.EmailAddress1, src.EmailAddress2, src.EmailAddress3 }))
            .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.InstitutionNumber, opts => opts.MapFrom(src => src.Vsd_InstitutionNo))
            .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
            .ForMember(dest => dest.RestChequeName, opts => opts.MapFrom(src => src.Vsd_Rest_ChequeName))
            .ForMember(dest => dest.SupplierSiteNumber, opts => opts.MapFrom(src => src.Vsd_SupplierSiteNumber))
            .ForMember(dest => dest.TransitNumber, opts => opts.MapFrom(src => src.Vsd_TransitNo));
    }
}