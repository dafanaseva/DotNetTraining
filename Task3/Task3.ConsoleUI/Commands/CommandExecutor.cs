using Task3.Models.Game;

namespace Task3.ConsoleUI.Commands;

internal sealed class CommandExecutor
{
    private readonly Dictionary<string, Command> _commands;

    private readonly ConsoleUi _consoleUi;
    private readonly Game _game;

    public CommandExecutor(ConsoleUi consoleUi, Game game)
    {
        _consoleUi = consoleUi;
        _game = game;
        _commands = new Dictionary<string, Command>();
    }

    public void RegisterCommand(string type, Command command)
    {
        _commands[type] = command;
    }

    public void ExecuteCommand(string commandText)
    {
        if (_commands.TryGetValue(commandText, out var command))
        {
            command.Execute(_consoleUi, _game);
        }
        else
        {
            throw new Exception("Wrong command");
        }
    }
}