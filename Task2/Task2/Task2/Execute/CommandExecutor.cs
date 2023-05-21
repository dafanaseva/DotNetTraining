using log4net;
using Task2.CreateCommands;
using Task2.Parse;
using ExecutionContext = Task2.CreateCommands.ExecutionContext;

namespace Task2.Execute;

internal sealed class CommandExecutor
{
    private readonly ILog _log;

    private readonly CommandCreator _commandCreator;
    private readonly CommandParser _commandParser;
    private readonly ExecutionContext _executionContext;

    public CommandExecutor(CommandParser commandCommandParser, CommandCreator commandCommandCreator)
    {
        _log = typeof(CommandExecutor).GetLogger();

        _commandParser = commandCommandParser;
        _commandCreator = commandCommandCreator;
        _executionContext = new ExecutionContext();
    }

    public void ExecuteCommandsFromStream(StreamReader streamReader)
    {
        while (!streamReader.EndOfStream)
        {
            var line = streamReader.ReadLine();

            if (string.IsNullOrEmpty(line))
            {
                _log.Info("Nothing entered");

                continue;
            }

            try
            {
                _log.Info($"Command: {line} is entered");

                _commandParser.Parse(line).Deconstruct(out var name, out var parameters);

                var command = _commandCreator.CreateCommand(name);

                command.Execute(_executionContext, parameters);
            }
            catch (UserException e)
            {
                _log.Error($"Na exception occured{e}");
                Console.WriteLine(e.Message);
            }
        }
    }
}