using System.Collections.Immutable;
using System.Diagnostics;
using Task3.Models.GameCell;

namespace Task3.Models.GameBoard;

internal static class InitializeCellsHelper
{
    public static Cell[,] CreateCells(Width width, Height height)
    {
        Debug.Assert(height.Value > 0);
        Debug.Assert(width.Value > 0);

        var cells = new Cell[width.Value, height.Value];

        for (var i = 0; i < width.Value; i++)
        {
            for (var j = 0; j < height.Value; j++)
            {
                cells[i, j] = new Cell();
            }
        }

        return cells;
    }

    public static (Cell[,] cells, ImmutableArray<Point> notMinedPoints) InitCells(
        BoardConfig config,
        Point point,
        Cell[,] cells)
    {
        var notMinedPoints =
            PutMinedCells(config.Width, config.Height, config.NumberOfMines, config.Seed, cells, point);

        InitNumberOfCells(config.Width, config.Height, cells);

        return (cells, notMinedPoints);
    }

    private static ImmutableArray<Point> PutMinedCells(
        Width width,
        Height height,
        int numberOfMines,
        int seed,
        Cell[,] cells,
        Point exceptPoint)
    {
        var exceptNumber = exceptPoint.GetFlatCoordinate(width.Value);

        var possibleCoordinates = Enumerable.Range(0, width.Value * height.Value).ToList();

        possibleCoordinates.RemoveAt(exceptNumber);

        if (!possibleCoordinates.Any())
        {
            return ImmutableArray<Point>.Empty;
        }

        var random = new Random(seed);

        for (var j = 0; j < numberOfMines; j++)
        {
            var i = random.Next(0, possibleCoordinates.Count);

            var mineIndex = possibleCoordinates[i];

            possibleCoordinates.RemoveAt(i);

            var point = Point.GetPoint(mineIndex, width.Value);

            cells[point.X, point.Y].IsMined = true;
        }

        var notMinedPoints = possibleCoordinates
            .Select(index => Point.GetPoint(index, width.Value)).ToList();

        notMinedPoints.Add(exceptPoint);

        return ImmutableArray.Create(notMinedPoints.ToArray());
    }

    private static void InitNumberOfCells(Width width, Height height, Cell[,] cells)
    {
        for (var i = 0; i < height.Value; i++)
        {
            for (var j = 0; j < width.Value; j++)
            {
                var numberOfMines = new Point(i, j).GetNeighbours(width, height)
                    .Count(t => cells[t.X, t.Y].IsMined);

                cells[i, j].NumberOfMinesAround = numberOfMines;
            }
        }
    }
}