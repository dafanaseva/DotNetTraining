namespace Task2.Configuration;

internal sealed class ConfigurationNotFoundException : UserException
{
    public ConfigurationNotFoundException(string parameterName) : base($"Configuration is not found for {parameterName}")
    {
    }
}