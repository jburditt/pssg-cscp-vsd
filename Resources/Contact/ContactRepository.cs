namespace Resources;

public class ContactRepository : BaseRepository<Database.Model.Contact, Contact>, IContactRepository
{
    private readonly DatabaseContext _databaseContext;

    public ContactRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
        _databaseContext = databaseContext;
    }

    public Contact FirstOrDefault(FindContactQuery query)
    {
        var entity = _databaseContext.ContactSet
            .Where(query)
            .FirstOrDefault();
        return _mapper.Map<Contact>(entity);
    }

    public IEnumerable<Contact> Query(ContactQuery query)
    {
        var entities = _databaseContext.ContactSet
            .Where(query)
            .ToList();
        return _mapper.Map<IEnumerable<Contact>>(entities);
    }
}

public static class ContactExtensions
{
    public static IQueryable<Database.Model.Contact> Where(this IQueryable<Database.Model.Contact> query, BaseContactQuery contactQuery)
    {
        return query.WhereIf(contactQuery.Id != null, c => c.Id == contactQuery.Id);
    }
}
