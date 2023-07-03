using Task3.Models.GameProcess;

namespace Task3.ConsoleUI.Commands;

internal sealed class HighScoresCommand : Command
{
    public override void Execute(ConsoleUi consoleUi, Game game)
    {
        consoleUi.PrintMessage($"High score = {game}");
    }
}