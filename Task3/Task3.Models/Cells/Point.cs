using System.Diagnostics;
using Task3.Models.Exceptions;

namespace Task3.Models.Cells;

internal sealed record Point
{
    public Point(int x, int y)
    {
        LessThenZeroArgumentException.ThrowIfLessThenZero(x);
        LessThenZeroArgumentException.ThrowIfLessThenZero(y);

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
        Debug.Assert(arrayWidth > 0, $"{nameof(arrayWidth)} > 0");
        Debug.Assert(numberOfElement > 0, $"{nameof(numberOfElement)} > 0");

        return new Point(numberOfElement / arrayWidth, numberOfElement % arrayWidth);
    }
}
