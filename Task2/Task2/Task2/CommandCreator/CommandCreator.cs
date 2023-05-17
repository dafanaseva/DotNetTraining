using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Text.Json;
using Task2.CommandCreator.Exceptions;

namespace Task2.CommandCreator;

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
            throw new UnknownCommandException($"Unknown command: {command}.");
        }

        var type = Type.GetType(typeName);
        if (type == null)
        {
            throw new Exception($"Wrong type {nameof(type)}");
        }

        var instance = Activator.CreateInstance(type);

        Debug.Assert(instance != null, $"{nameof(instance)} != null");

        return (Command)instance;
    }
}