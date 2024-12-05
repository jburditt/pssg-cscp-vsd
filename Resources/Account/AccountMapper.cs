public class AccountMapper : Profile
{
    public AccountMapper()
    {
        CreateMap<Database.Model.Account, Account>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.AccountNumber))
            .ForMember(dest => dest.SupplierSiteNumber, opt => opt.MapFrom(src => src.Vsd_SupplierSiteNumber))
            .ForMember(dest => dest.RestChequeName, opt => opt.MapFrom(src => src.Vsd_Rest_ChequeName))
            .ForMember(dest => dest.StateCode, opt => opt.MapFrom(src => src.StateCode))
            .ForMember(
                dest => dest.Addresses, 
                opt => opt.MapFrom(src => new Address[] {
                new Address(
                    Address.MapAddress1Code((int?)src.Address1_AddressTypeCode),
                    src.Address1_Line1,
                    src.Address1_Line2,
                    src.Address1_Line3,
                    src.Address1_City,
                    src.Address1_StateOrProvince,
                    src.Address1_PostalCode),
                new Address(
                    Address.MapAddress2Code((int?)src.Address2_AddressTypeCode),
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