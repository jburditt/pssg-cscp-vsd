namespace Manager;

public class ConfigurationHandlers(IConfigurationRepository repository, IConfigurationService service) : QueryBaseHandlers<IConfigurationRepository, Configuration, ConfigurationQuery>(repository),
    IRequestHandler<ConfigurationQuery, IEnumerable<Configuration>>,
    IRequestHandler<GetKeyValueCommand, string>
{
    public async Task<string> Handle(GetKeyValueCommand command, CancellationToken token)
    {
        return await Task.FromResult(service.GetKeyValue(command.Configurations, command.Key, command.Group, command.ProgramUnit));
    }
}
