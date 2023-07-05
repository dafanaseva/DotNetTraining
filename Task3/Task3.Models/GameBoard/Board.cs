using System.Diagnostics;
using Task3.Models.GameCell;

namespace Task3.Models.GameBoard;

internal sealed partial class Board
{
    private readonly int _seed;

    private bool _isInitialized;

    private Cell[,] Cells { get; }
    public int Width { get; }
    public int Height { get; }
    public int ClosedCellsCount { get; private set; }
    public int NumberOfMines { get; }

    public Board(BoardConfig boardConfig, int seed)
    {
        var height = boardConfig.Height;
        var width = boardConfig.Width;
        var countOfMines = boardConfig.NumberOfMines;

        Debug.Assert(height > 0);
        Debug.Assert(width > 0);
        Debug.Assert(countOfMines > 0);

        Width = width;
        Height = height;

        var fullWidth = GetFullLength(width);
        var fullHeight = GetFullLength(height);

        NumberOfMines = countOfMines;

        _seed = seed;

        _isInitialized = false;

        Cells = new Cell[fullWidth, fullHeight];

        for (var i = 0; i < fullWidth; i++)
        {
            for (var j = 0; j < fullHeight; j++)
            {
                Cells[i, j] = new Cell();
            }
        }
    }

    private static IEnumerable<Point> GetNeighbours(Point point)
    {
        var (x, y) = point;

        yield return new Point(x - 1, y);
        yield return new Point(x + 1, y);
        yield return new Point(x , y - 1);
        yield return new Point(x , y + 1);
        yield return new Point(x - 1, y + 1);
        yield return new Point(x + 1, y - 1);
        yield return new Point(x + 1, y + 1);
        yield return new Point(x - 1, y - 1);
    }

    public Cell this[int x, int y] => Cells[x + BorderWidth, y + BorderWidth];
}