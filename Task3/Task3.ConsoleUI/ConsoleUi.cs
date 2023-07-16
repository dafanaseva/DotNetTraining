using Task3.Models.GameCell;

namespace Task3.ConsoleUI;

internal sealed class ConsoleUi
{
    private readonly Cell[,]  _cells;
    private readonly TextWriter _writer;

    public ConsoleUi(TextWriter writer, Cell[,] cells)
    {
        _cells = cells;
        _writer = writer;
    }

    public void PrintBoard()
    {
        for (var i = 0; i < _cells.GetHeight().Value; i++)
        {
            for (var j = 0; j < _cells.GetWidth().Value; j++)
            {
                var cell = _cells[i, j];

                _writer.Write($"|{GetValue(cell)}| ");
            }

            _writer.WriteLine();
        }
    }

    public void PrintMessage(string message)
    {
        _writer.WriteLine(message);
    }

    private static string GetValue(Cell cell)
    {
        return cell.GetState() switch
        {
            CellState.Unknown => string.Empty,
            CellState.Safe => cell.NumberOfMinesAround.ToString(),
            CellState.Mine => "X",
            CellState.Flag => "?",
            _ => throw new ArgumentOutOfRangeException(nameof(CellState))
        };
    }
}