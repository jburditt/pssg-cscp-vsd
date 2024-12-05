namespace Resources;

public class ContactRepository : IContactRepository
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMapper _mapper;

    public ContactRepository(DatabaseContext databaseContext, IMapper mapper)
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }

    public Contact FirstOrDefault(FindContactQuery query)
    {
        var queryResults = _databaseContext.ContactSet
            .Where(query)
            .FirstOrDefault();
        return _mapper.Map<Contact>(queryResults);
    }
}

public static class ContactExtensions
{
    public static IQueryable<Database.Model.Contact> Where(this IQueryable<Database.Model.Contact> query, BaseContactQuery contactQuery)
    {
        return query.WhereIf(contactQuery.Id != null, c => c.Id == contactQuery.Id);
    }
}
