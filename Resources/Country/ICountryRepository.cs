namespace Resources;

public interface ICountryRepository : IFindRepository<FindCountryQuery, Country> 
{
    Country Single(SingleCountryQuery query);
}
