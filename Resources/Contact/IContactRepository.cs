namespace Resources;

public interface IContactRepository : IFindRepository<FindContactQuery, Contact>, IQueryRepository<ContactQuery, Contact>, IBaseRepository<Contact> { }
