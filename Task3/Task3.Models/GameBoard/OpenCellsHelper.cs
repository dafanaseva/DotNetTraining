using Task3.Models.Exceptions;
using Task3.Models.GameCell;

namespace Task3.Models.GameBoard;

internal static class OpenCellsHelper
{
    public static void OpenNotMinedCells(Point point, Cell[,] cells)
    {
        OpenCells(
            point: point,
            cells: cells,
            exceptCondition: neighbour => !cells[neighbour.X, neighbour.Y].IsMined,
            shouldOpenCondition: neighbour => cells[neighbour.X, neighbour.Y].NumberOfMinesAround == 0);
    }

    public static void OpenAllCells(Point point, Cell[,] cells)
    {
        OpenCells(
            point: point,
            cells: cells,
            exceptCondition: _ => true,
            shouldOpenCondition: _ => true);
    }

    private static void OpenCells(
        Point point,
        Cell[,] cells,
        Func<Point, bool> exceptCondition,
        Func<Point, bool> shouldOpenCondition)
    {
        var width = cells.GetWidth();
        var height = cells.GetHeight();

        AssertPoint(point, width, height);

        var nextCells = new Queue<Point>();
        var seenCells = new HashSet<Point>();

        nextCells.Enqueue(point);
        seenCells.Add(point);

        while (nextCells.Any())
        {
            var node = nextCells.Dequeue();

            foreach (var neighbour in node.GetNeighbours(width, height)
                         .Where(neighbour => seenCells.All(t => t != neighbour))
                         .Where(exceptCondition))
            {
                cells[neighbour.X, neighbour.Y].Open();

                seenCells.Add(neighbour);

                if (shouldOpenCondition(neighbour))
                {
                    nextCells.Enqueue(neighbour);
                }
            }
        }

        cells[point.X, point.Y].Open();
    }

    private static void AssertPoint(Point point, Width width, Height height)
    {
        if (!Point.IsInBounds(point.X, width.Value) || !Point.IsInBounds(point.Y, height.Value))
        {
            throw new OutOfBoundsArgumentException("Point is outside of the board");
        }
    }
}