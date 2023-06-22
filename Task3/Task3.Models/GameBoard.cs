namespace Task3.Models;

internal sealed class GameBoard
{
    private const int BoundWidth = 1;
    private const int BoundsCount = 2;
    private Cell[,] Cells { get; }
    public int Width { get; }
    public int Height { get; }

    public GameBoard(int height, int width)
    {
        LessThenZeroArgumentException.ThrowIfLessThenZero(height);
        LessThenZeroArgumentException.ThrowIfLessThenZero(width);

        Width = width;
        Height = height;

        var widthWithSentinel = width + BoundsCount * BoundWidth;
        var heightWithSentinel = height + BoundsCount * BoundWidth;

        Cells = new Cell[widthWithSentinel, heightWithSentinel];

        for (var i = 0; i < heightWithSentinel; i++)
        {
            for (var j = 0; j < widthWithSentinel; j++)
            {
                var cell = new Cell();
                Cells[i, j] = cell;
            }
        }

        for (var i = 1; i < Height+BoundWidth; i++)
        {
            for (var j = 1; j < Width+BoundWidth; j++)
            {
                Cells[i, j].Neighbours = GetNeighbours(i, j).ToList();
            }
        }
    }

    private IEnumerable<Cell> GetNeighbours(int x, int y)
    {
        var result = new List<Cell>();

        const int maxNeighbourIndex = 2;
        const int minNeighbourIndex = -1;

        for (var i = minNeighbourIndex; i < maxNeighbourIndex; i++)
        {
            for (var j = minNeighbourIndex; j < maxNeighbourIndex; j++)
            {
                var neighborX = x + i;
                var neighborY = y + j;

                result.Add(Cells[neighborX, neighborY]);
            }
        }

        return result;
    }

    public Cell this[int x, int y] => Cells[x + BoundWidth, y + BoundWidth];
}