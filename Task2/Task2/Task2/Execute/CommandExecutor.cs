using log4net;
using Task2.CreateCommands;
using Task2.Parse;
using ExecutionContext = Task2.CreateCommands.ExecutionContext;

namespace Task2.Execute;

internal sealed class CommandExecutor
{
    private readonly ILog _log;

    private readonly ICommandCreator _commandCreator;
    private readonly ICommandParser _commandParser;

    private readonly IExecutionContext _executionContext;

    public CommandExecutor(ICommandParser commandCommandParser, ICommandCreator commandCommandCreator)
    {
        _log = typeof(CommandExecutor).GetLogger();

        _commandParser = commandCommandParser;
        _commandCreator = commandCommandCreator;

        _executionContext = new ExecutionContext();
    }

    public void ExecuteCommand(string? commandText)
    {
        _log.Info($"Start executing command: {commandText}");

        if (string.IsNullOrEmpty(commandText) || string.IsNullOrWhiteSpace(commandText))
        {
            _log.Info("Command is empty. Skipping.");

            return;
        }

        try
        {
            _commandParser.Parse(commandText).Deconstruct(out var name, out var parameters);

            var command = _commandCreator.CreateCommand(name);

            command.Execute(_executionContext, parameters);
        }
        catch (UserException e)
        {
            _log.Exception(e);

            Console.WriteLine(e.Message);
        }
    }
}