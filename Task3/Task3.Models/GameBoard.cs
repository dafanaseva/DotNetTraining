using System.Diagnostics;

namespace Task3.Models;

internal sealed class GameBoard
{
    private Cell[,] Cells { get; }

    public int Width { get; }
    public int Height { get; }

    public GameBoard(int height, int width)
    {
        NegativeArgumentException.ThrowIfLessThenNull(height);
        NegativeArgumentException.ThrowIfLessThenNull(width);

        Width = width;
        Height = height;

        Cells = new Cell[width, height];

        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                Cells[i, j] = new Cell();
            }
        }
    }

    public List<Point> GetNeighbours(int x, int y)
    {
        AssertArrayBounds(x, y);

        var result = new List<Point>();

        const int maxNeighbourIndex = 2;
        const int minNeighbourIndex = -1;

        for (var i = minNeighbourIndex; i < maxNeighbourIndex; i++)
        {
            for (var j = minNeighbourIndex; j < maxNeighbourIndex; j++)
            {
                var neighborX = x + i;
                if (neighborX < 0 || neighborX >= Width)
                {
                    continue;
                }

                var neighborY = y + j;
                if (neighborY < 0 || neighborY >= Height)
                {
                    continue;
                }

                result.Add(new Point(neighborX, neighborY));
            }
        }

        return result;
    }

    public Cell this[int x, int y]
    {
        get
        {
            AssertArrayBounds(x, y);

            return Cells[x, y];
        }
    }

    private void AssertArrayBounds(int x, int y)
    {
        Debug.Assert(x < Width, "x < Width");
        Debug.Assert(y < Height, "x < Height");
    }
}