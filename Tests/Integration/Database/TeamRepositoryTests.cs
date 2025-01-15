public class TeamRepositoryTests(ITeamRepository repository)
{
    // WARNING!!! these are not reliable tests, they will fail, these were shortcuts I used for building a POC, these tests will need to be adjusted in order to be idempotent

    [Fact]
    public void Find()
    {
        var query = new FindTeamQuery();
        
        var result = repository.FirstOrDefault(query);

        Assert.NotNull(result);
    }
}