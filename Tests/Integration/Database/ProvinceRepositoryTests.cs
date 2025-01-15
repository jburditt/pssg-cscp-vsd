public class ProvinceRepositoryTests(IProvinceRepository repository)
{
    [Fact]
    public void FirstOrDefault()
    {
        var query = new FindProvinceQuery { Id = Constant.ProvinceBc };
        var province = repository.FirstOrDefault(query);
        Assert.NotNull(province);
    }
}
