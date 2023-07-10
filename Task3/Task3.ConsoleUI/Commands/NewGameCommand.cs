using System.Diagnostics;
using Task3.Models.GameBoard;
using Task3.Models.GameCell;
using Task3.Models.GameProcess;

namespace Task3.ConsoleUI.Commands;

internal sealed class NewGameCommand : Command
{
    public override void Execute(ConsoleUi consoleUi, Game game, params string[] parameter)
    {
        Debug.Assert(parameter is not null);

        if (parameter.Length != (int)Coordinate.Count + 1)
        {
            throw new UnknownCommandException();
        }

        var width = CommandParser.ParseInt(parameter[(int)Coordinate.X]);
        var height = CommandParser.ParseInt(parameter[(int)Coordinate.Y]);
        var numberOfMines = CommandParser.ParseInt(parameter[(int)Coordinate.Count]);

        game.StartNew(new Board(new BoardConfig(width, height, numberOfMines, Environment.TickCount)));

        consoleUi.PrintBoard();
    }
}