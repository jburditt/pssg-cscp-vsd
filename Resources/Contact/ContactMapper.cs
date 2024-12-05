public class ContactMapper : Profile
{
    public ContactMapper()
    {
        CreateMap<Database.Model.Contact, Contact>();
    }
}