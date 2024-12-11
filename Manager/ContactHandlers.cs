namespace Manager;

public class ContactHandlers(IContactRepository repository, IMapper mapper) : FindQueryBaseHandlers<IContactRepository, Contact, FindContactQuery, ContactQuery>(repository)
{

}
