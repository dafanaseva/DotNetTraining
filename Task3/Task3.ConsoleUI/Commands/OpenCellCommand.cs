using System.Diagnostics;
using Task3.Models.GameCell;
using Task3.Models.GameProcess;

namespace Task3.ConsoleUI.Commands;

internal sealed class OpenCellCommand : Command
{
    public override void Execute(ConsoleUi consoleUi, Game game, params string[] parameter)
    {
        Debug.Assert(parameter is not null);

        if (parameter.Length != (int)Coordinate.Count)
        {
            throw new UnknownCommandException();
        }

        var x = CommandParser.ParseInt(parameter[(int)Coordinate.X]);
        var y = CommandParser.ParseInt(parameter[(int)Coordinate.Y]);

        game.OpenCell(new Point(x, y));

        consoleUi.PrintBoard();
    }

}