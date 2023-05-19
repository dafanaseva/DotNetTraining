using System.Diagnostics;
using System.Diagnostics.Contracts;
using Task2.Create.Exceptions;

namespace Task2.Create;

internal sealed class CommandCreator
{
    private readonly Dictionary<string, Type?> _commands;

    public CommandCreator(Dictionary<string, Type?> commandTypes)
    {
        _commands = commandTypes;
    }

    [Pure]
    public Command CreateCommand(string commandName)
    {
        if (!_commands.TryGetValue(commandName, out var typeName))
        {
            throw new UnknownCommandException($"Unknown command: {commandName}.");
        }

        if (typeName == null)
        {
            throw new UnknownCommandException("Command type is invalid");
        }

        var instance = Activator.CreateInstance(typeName);

        Debug.Assert(instance != null, $"{nameof(instance)} != null");

        return (Command)instance;
    }
}