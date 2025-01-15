namespace Utilities;

public interface IConfigurationService
{
    string GetKeyValue(IEnumerable<Configuration> configurations, string key, string group, ProgramUnit? programUnit);
}

public class ConfigurationService : IConfigurationService
{
    public string GetKeyValue(IEnumerable<Configuration> configurations, string key, string? group, ProgramUnit? programUnit)
    {
        ArgumentException.ThrowIfNullOrEmpty(key);

        foreach (var configEntity in configurations)
        {
            if (configEntity.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase))
            {
                bool isFinal;
                if (!string.IsNullOrEmpty(group))
                {
                    if (configEntity.Group.Equals(group, StringComparison.InvariantCultureIgnoreCase))
                        isFinal = true;
                    else
                        isFinal = false;
                }
                else
                    isFinal = true;

                if (programUnit.HasValue && isFinal)
                {
                    if (configEntity.ProgramUnit != null && configEntity.ProgramUnit == programUnit)
                        isFinal = true;
                    else
                        isFinal = false;
                }

                if (isFinal)
                    return configEntity.Value;
            }
        }

        throw new Exception(string.Format("Unable to find configuration with Key '{0}', Group '{1}'..", key, group));
    }
}
