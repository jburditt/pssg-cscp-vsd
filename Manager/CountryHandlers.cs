
namespace Manager;

public class CountryHandlers(ICountryRepository repository, IMapper mapper) :
    IRequestHandler<SingleCountryQuery, Country>
{
    public Task<Country> Handle(SingleCountryQuery request, CancellationToken cancellationToken)
    {
        var entity = repository.Single(request);
        var dto = mapper.Map<Country>(entity);
        return Task.FromResult(dto);
    }
}
