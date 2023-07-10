using Task3.Models.GameProcess;

namespace Task3.ConsoleUI.Commands;

internal abstract class Command
{
    public abstract void Execute(ConsoleUi consoleUi, Game game, params string[] parameter);
}