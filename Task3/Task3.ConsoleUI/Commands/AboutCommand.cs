using Task3.Models.Game;

namespace Task3.ConsoleUI.Commands;

internal sealed class AboutCommand : Command
{
    public override void Execute(ConsoleUi consoleUi, Game game)
    {
        consoleUi.PrintMessage("This is a minesweeper game");
    }
}