using Task3.Models.GameProcess;

namespace Task3.ConsoleUI.Commands;

internal sealed class CommandExecutor
{
    private readonly Dictionary<string, Command> _commands;

    private readonly ConsoleUi _consoleUi;
    private readonly Game _game;

    public CommandExecutor(ConsoleUi consoleUi, Game game, Dictionary<string, Command> commands)
    {
        _consoleUi = consoleUi;
        _game = game;
        _commands = commands;
    }

    public void ExecuteCommand((string Name, string[] Parameters) inputCommand)
    {
        if (_commands.TryGetValue(inputCommand.Name.ToLowerInvariant(), out var command))
        {
            command.Execute(_consoleUi, _game, inputCommand.Parameters);
        }
        else
        {
            throw new UnknownCommandException($"Wrong command: {inputCommand.Name}");
        }
    }
}