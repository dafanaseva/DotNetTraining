using Task3.Models.Exceptions;

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
