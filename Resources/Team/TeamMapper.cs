namespace Resources;

public class TeamMapper : Profile
{
    public TeamMapper()
    {
        CreateMap<Database.Model.Team, Manager.Contract.Team>();
    }
}
