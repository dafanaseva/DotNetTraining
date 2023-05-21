using System.Diagnostics;
using System.Diagnostics.Contracts;
using Task2.CreateCommands.Exceptions;

namespace Task2.CreateCommands;

internal sealed class CommandCreator
{
    private readonly Dictionary<string, string> _commands;
    private readonly string _namespace;

    public CommandCreator(Dictionary<string, string> commandTypes, string @namespace)
    {
        _commands = commandTypes;
        _namespace = @namespace;
    }

    [Pure]
    public Command CreateCommand(string commandName)
    {
        if (!_commands.TryGetValue(commandName, out var typeName))
        {
            throw new UnknownCommandException($"Unknown command: {commandName}.");
        }

        var type = GetType(typeName);

        if (type == null)
        {
            throw new UnknownCommandException($"Unknown command type: {nameof(type)}");
        }

        var instance = Activator.CreateInstance(type);

        Debug.Assert(instance != null, $"{nameof(instance)} != null");

        return (Command)instance;
    }

    private Type? GetType(string className)
    {
        return Type.GetType($"{_namespace}.{className}");
    }
}