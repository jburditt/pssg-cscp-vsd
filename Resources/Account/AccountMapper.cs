public class AccountMapper : Profile
{
    public AccountMapper()
    {
        CreateMap<Database.Model.Account, Account>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.AccountNumber))
            .ForMember(dest => dest.TransitNumber, opt => opt.MapFrom(src => src.Vsd_TransitNo))
            .ForMember(dest => dest.InstitutionNumber, opt => opt.MapFrom(src => src.Vsd_InstitutionNo))
            .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => new string[3] { src.EmailAddress1, src.EmailAddress2, src.EmailAddress3 }))
            .ForMember(dest => dest.SupplierSiteNumber, opt => opt.MapFrom(src => src.Vsd_SupplierSiteNumber))
            .ForMember(dest => dest.RestChequeName, opt => opt.MapFrom(src => src.Vsd_Rest_ChequeName))
            .ForMember(dest => dest.StateCode, opt => opt.MapFrom(src => src.StateCode))
            .ForMember(dest => dest.Address1Code, opt => opt.MapFrom(src => src.Address1_AddressTypeCode))
            .ForMember(dest => dest.Address2Code, opt => opt.MapFrom(src => src.Address2_AddressTypeCode))
            .ForMember(
                dest => dest.Addresses, 
                opt => opt.MapFrom(src => new Address[2] {
                new Address(
                    src.Address1_Line1,
                    src.Address1_Line2,
                    src.Address1_Line3,
                    src.Address1_City,
                    src.Address1_StateOrProvince,
                    src.Address1_PostalCode),
                new Address(
                    src.Address2_Line1,
                    src.Address2_Line2,
                    src.Address2_Line3,
                    src.Address2_City,
                    src.Address2_StateOrProvince,
                    src.Address2_PostalCode)
                }));

        //CreateMap<Account, Database.Model.Account>()
        //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        //    .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.AccountNumber))
        //    .ForMember(dest => dest.SupplierSiteNumber, opt => opt.MapFrom(src => src.SupplierSiteNumber))
        //    .ForMember(dest => dest.RestChequeName, opt => opt.MapFrom(src => src.RestChequeName))
        //    .ForMember(dest => dest.StateCode, opt => opt.MapFrom(src => src.StateCode))
        //    .ForMember(dest => dest.AccountAddresses, opt => opt.MapFrom(src => src.Addresses.Select(a => new Address
        //    {
        //        AddressTypeCode = a.Address1Code,
        //        Address1 = a.AddressLine1,
        //        Address2 = a.AddressLine2,
        //        Address3 = a.AddressLine3,
        //        City = a.City,
        //        State = a.State,
        //        PostalCode = a.PostalCode
        //    }));
    }
}