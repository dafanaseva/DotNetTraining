using System.Diagnostics.Contracts;
using System.Text.Json;

namespace Task2.Calculator;

internal sealed class CommandCreator
{
    private readonly Dictionary<string, string> _commands;

    public CommandCreator(string config)
    {
        using var file = new StreamReader(config);
        var output = file.ReadToEnd();

        _commands = JsonSerializer.Deserialize<Dictionary<string, string>>(output) ?? new Dictionary<string, string>();
    }

    [Pure]
    public Command CreateCommand(string command)
    {
        if (!_commands.TryGetValue(command, out var typeName))
        {
            throw new ArgumentException(command);
        }

        var type = Type.GetType(typeName);
        if (type == null)
        {
            throw new ArgumentException(typeName);
        }

        var instance = Activator.CreateInstance(type);
        if (instance == null)
        {
            throw new Exception("Failed to create command instance");
        }

        return (Command)instance;
    }
}