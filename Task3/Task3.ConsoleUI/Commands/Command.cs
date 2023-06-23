using Task3.Models.Game;

namespace Task3.ConsoleUI.Commands;

internal abstract class Command
{
    public abstract void Execute(ConsoleUi consoleUi, Game game);
}