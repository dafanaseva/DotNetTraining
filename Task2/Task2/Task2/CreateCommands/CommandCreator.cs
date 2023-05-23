using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using log4net;
using Task2.CreateCommands.Exceptions;

namespace Task2.CreateCommands;

internal sealed class CommandCreator : ICommandCreator
{
    private readonly ReadOnlyDictionary<string, string> _commands;
    private readonly string _namespace;

    private readonly ILog _log;

    public CommandCreator(IDictionary<string, string> commandTypes, string @namespace)
    {
        _commands = new ReadOnlyDictionary<string, string>(commandTypes);
        _namespace = @namespace;

        _log = typeof(CommandCreator).GetLogger();
    }

    [Pure]
    public Command CreateCommand(string commandName)
    {
        _log.Info($"Start creating command with name '{commandName}'.");

        if (!_commands.TryGetValue(commandName, out var typeName))
        {
            throw new UnknownCommandException($"Unknown command: '{commandName}'.");
        }

        var type = GetType(typeName);

        if (type == null)
        {
            throw new UnknownCommandException($"Unknown command type: {type}.");
        }

        _log.Info($"Creating command of type: '{type}'.");

        var instance = Activator.CreateInstance(type);

        Debug.Assert(instance != null, $"{nameof(instance)} != null");

        return (Command)instance;
    }

    private Type? GetType(string className)
    {
        return Type.GetType($"{_namespace}.{className}");
    }
}