using Task3.Models.Game;

namespace Task3.ConsoleUI;

internal sealed class ConsoleUi
{
    private readonly Game _game;
    private readonly TextWriter _writer;

    public ConsoleUi(TextWriter writer, Game game)
    {
        _game = game;
        _writer = writer;
    }

    public void PrintGameBoard()
    {
        for (var i = 0; i < _game.Board.Height; i++)
        {
            for (var j = 0; j < _game.Board.Width; j++)
            {
                var cell = _game.Board[i, j];
                _writer.Write($"|{cell.GetState()}| ");
            }

            _writer.WriteLine();
        }
    }

    public void PrintMessage(string message)
    {
        _writer.WriteLine(message);
    }
}