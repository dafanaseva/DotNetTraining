using Task3.Models.Exceptions;
using Task3.Models.GameBoard;

namespace Task3.Models.GameCell;

internal sealed record Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        LessThenZeroArgumentException.ThrowIfLessThenZero(x);
        LessThenZeroArgumentException.ThrowIfLessThenZero(y);

        X = x;
        Y = y;
    }

    public int GetFlatCoordinate(int width)
    {
        AssertArrayWidth(width);

        return X * width + Y;
    }

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }

    public static Point GetPoint(int numberOfElement, int arrayWidth)
    {
        LessThenZeroArgumentException.ThrowIfLessThenZero(numberOfElement);

        AssertArrayWidth(arrayWidth);

        return new Point(numberOfElement / arrayWidth, numberOfElement % arrayWidth);
    }

    private static readonly int[] Diff = { -1, 0, 1 };

    public IEnumerable<Point> GetNeighbours(Width width, Height height)
    {
        foreach (var dx in Diff)
        {
            foreach (var dy in Diff)
            {
                var neighbourX = X + dx;
                var neighbourY = Y + dy;

                if (!IsInBounds(neighbourX, width.Value) || !IsInBounds(neighbourY, height.Value))
                {
                    continue;
                }

                var neighbour = new Point(neighbourX, neighbourY);

                if (neighbour != this)
                {
                    yield return neighbour;
                }
            }
        }
    }

    public static bool IsInBounds(int coordinate, int length)
    {
        return coordinate >= 0 && coordinate < length;
    }

    public static Point operator +(Point a, Point b) => new(a.X + b.X, a.Y + b.Y);

    private static void AssertArrayWidth(int width)
    {
        if (width == 0)
        {
            throw new OutOfBoundsArgumentException($"The {nameof(width)} can not be equal to zero: {width}");
        }

        LessThenZeroArgumentException.ThrowIfLessThenZero(width);
    }
}
