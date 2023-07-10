using Task3.Models.GameBoard;
using Task3.Models.GameCell;

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

    public void PrintBoard()
    {
        for (var i = 0; i < _board.Height; i++)
        {
            for (var j = 0; j < _board.Width; j++)
            {
                var cell = _board[i, j];

                _writer.Write($"|{GetValue(cell)}| ");
            }

            _writer.WriteLine();
        }
    }

    public void PrintMessage(string message)
    {
        _writer.WriteLine(message);
    }

    //todo: get rid of duplicates
    private static string GetValue(Cell cell)
    {
        var cellState = cell.GetState();

        var numberOfMinesSymbol = cell.NumberOfMinesAround > 0 ? cell.NumberOfMinesAround.ToString() : string.Empty;

        return GetValue(cellState, cell.IsOpen, numberOfMinesSymbol);
    }

    private static string GetValue(CellState state, bool isOpen, string numberOfMinesSymbol)
    {
        return state switch
        {
            CellState.Safe => isOpen ? numberOfMinesSymbol : string.Empty,
            CellState.Mine => isOpen ? "X" : string.Empty,
            CellState.Flag => isOpen ? numberOfMinesSymbol : "?",
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
        };
    }
}