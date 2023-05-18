using Task2.CommandCreator.Exceptions;
using Task2.CommandParser;
using ExecutionContext = Task2.CommandCreator.ExecutionContext;

namespace Task2;

internal sealed class CommandRunner
{
    private readonly CommandCreator.CommandCreator _commandCreator;
    private readonly ExecutionContext _executionContext;

    public CommandRunner(Dictionary<string, Type?> commandTypes)
    {
        _commandCreator = new CommandCreator.CommandCreator(commandTypes);
        _executionContext = new ExecutionContext();
    }

    public void RunCommand(string commandText)
    {
        try
        {
            var commandData = CommandParser.CommandParser.Parse(commandText);

            var command = _commandCreator.CreateCommand(commandData.Name);
            command.Execute(_executionContext, commandData.Parameters);
        }
        catch (Exception e) when (e is ParseCommandException or UnknownCommandException)
        {
            Console.WriteLine($"Entered command is invalid: {e.Message}. Please correct the command and try again.");
        }
        catch (Exception e) when (e is InvalidCommandArgumentException or DivideByZeroException)
        {
            Console.WriteLine($"Argument is invalid: {e.Message}");
        }
    }
}