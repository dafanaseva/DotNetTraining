using System.Diagnostics;

namespace Task3.Models.Cells;

internal sealed record Point(int X, int Y)
{
    public static Point GetPoint(int numberOfElement, int arrayWidth)
    {
        Debug.Assert(arrayWidth > 0);

        return new Point(numberOfElement / arrayWidth, numberOfElement % arrayWidth);
    }

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }

    //todo: may be also other operators?
    public static Point operator +(Point a, Point b) => new(a.X + b.X, a.Y + b.Y);

    public int GetFlatCoordinate(int width)
    {
        return X * width + Y;
    }
}
