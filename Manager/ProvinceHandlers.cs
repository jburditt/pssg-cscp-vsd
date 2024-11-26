namespace Manager;

public class ProvinceHandlers(IProvinceRepository repository) : FindQueryBaseHandlers<IProvinceRepository, Province, FindProvinceQuery, ProvinceQuery>(repository),
    IRequestHandler<FindProvinceQuery, Province>
{

}
