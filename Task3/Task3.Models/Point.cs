using System.Diagnostics;

namespace Task3.Models;

internal sealed record Point
{
    public Point(int x, int y)
    {
        NegativeArgumentException.ThrowIfLessThenNull(x);
        NegativeArgumentException.ThrowIfLessThenNull(y);

        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }

    public static Point GetPoint(int numberOfElement, int arrayWidth)
    {
        Debug.Assert(arrayWidth > 0, "arrayWidth > 0");

        return new Point(numberOfElement / arrayWidth, numberOfElement % arrayWidth);
    }
}
