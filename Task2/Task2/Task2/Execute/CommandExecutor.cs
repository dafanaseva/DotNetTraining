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

    private const int EndOfStream = -1;

    public CommandExecutor(ICommandParser commandCommandParser, ICommandCreator commandCommandCreator)
    {
        _log = typeof(CommandExecutor).GetLogger();

        _commandParser = commandCommandParser;
        _commandCreator = commandCommandCreator;

        _executionContext = new ExecutionContext();
    }

    public void ExecuteCommands(TextReader textReader)
    {
        while (textReader.Peek() != EndOfStream)
        {
            var line = textReader.ReadLine();

            if (string.IsNullOrEmpty(line))
            {
                _log.Info("Nothing has been entered");

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
                _log.Exception(e);

                Console.WriteLine(e.Message);
            }
        }
    }
}