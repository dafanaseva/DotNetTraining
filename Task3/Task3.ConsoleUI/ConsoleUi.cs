using Task3.Models.GameBoard;

namespace Task3.ConsoleUI;

internal sealed class ConsoleUi
{
    private readonly Board _board;
    private readonly TextWriter _writer;

    public ConsoleUi(TextWriter writer, Board board)
    {
        _board = board;
        _writer = writer;
    }

    public void PrintGameBoard()
    {
        for (var i = 0; i < _board.Height; i++)
        {
            for (var j = 0; j < _board.Width; j++)
            {
                var cell = _board[i, j];
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