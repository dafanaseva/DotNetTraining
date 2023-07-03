using Task3.Models.Exceptions;
using Task3.Models.GameCell;
using Task3.Models.GameProcess;

namespace Task3.Models.GameBoard;

internal sealed partial class Board
{
    private readonly int _countOfMines;
    private readonly int _seed;

    private bool _isInitialized;
    private Cell[,] Cells { get; }

    public int Width { get; }
    public int Height { get; }

    public Board(BoardConfig boardConfig, int seed)
    {
        // todo: add more asserts
        var height = boardConfig.Height;
        var width = boardConfig.Width;
        var countOfMines = boardConfig.NumberOfMines;

        LessThenZeroArgumentException.ThrowIfLessThenZero(height);
        LessThenZeroArgumentException.ThrowIfLessThenZero(width);

        Width = width;
        Height = height;

        var fullWidth = Border.GetFullLength(width);
        var fullHeight = Border.GetFullLength(height);

        LessThenZeroArgumentException.ThrowIfLessThenZero(countOfMines);

        _countOfMines = countOfMines;

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

    public Cell this[int x, int y] => Cells[x + Border.Width, y + Border.Width];
}