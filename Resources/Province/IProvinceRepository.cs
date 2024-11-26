namespace Resources;

public interface IProvinceRepository : IFindRepository<FindProvinceQuery, Province>, IQueryRepository<ProvinceQuery, Province>, IBaseRepository<Province>
{
}
