using System.Diagnostics;
using Task3.Models.Exceptions;
using Task3.Models.GameCell;

namespace Task3.Models.GameBoard;

internal sealed class Board
{
    private bool _isInitialized;
    private readonly int _seed;
    private Cell[,] Cells { get; }

    public int Width { get; }
    public int Height { get; }
    public int ClosedCellsCount { get; private set; }
    public int NumberOfMines { get; }

    public Board(BoardConfig config)
    {
        Debug.Assert(config.Height > 0);
        Debug.Assert(config.Width > 0);
        Debug.Assert(config.NumberOfMines > 0);

        Width = config.Width;
        Height = config.Height;
        NumberOfMines = config.NumberOfMines;

        ClosedCellsCount = Width * Height;

        Cells = new Cell[Width, Height];

        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                Cells[i, j] = new Cell();
            }
        }

        _seed = config.Seed;
        _isInitialized = false;
    }

    public void InitializeCells(Point point)
    {
        if(!Point.IsInBounds(point.X, Width) || !Point.IsInBounds(point.Y, Height))
        {
            throw new OutOfBoundsArgumentException("Point is outside of the board");
        }

        if (_isInitialized)
        {
            return;
        }

        PutMinedCells(point, _seed);
        InitNumberOfCells();

        _isInitialized = true;
    }

    public Cell this[int x, int y] => Cells[x, y];

    public void OpenNotMinedCells(Point point)
    {
        OpenCells(
            point: point,
            exceptCondition: neighbour => !Cells[neighbour.X, neighbour.Y].IsMined,
            shouldOpenCondition: neighbour => Cells[neighbour.X, neighbour.Y].NumberOfMinesAround == 0);
    }

    public void OpenAllCells(Point point)
    {
        OpenCells(point: point, exceptCondition: _ => true, shouldOpenCondition: _ => true);
    }

    //todo: update flagged cells
    private void OpenCells(Point point, Func<Point, bool> exceptCondition, Func<Point, bool> shouldOpenCondition)
    {
        var nextCells = new Queue<Point>();
        var seenCells = new HashSet<Point>();

        nextCells.Enqueue(point);
        seenCells.Add(point);

        while (nextCells.Any())
        {
            var node = nextCells.Dequeue();

            foreach (var neighbour in node.GetNeighbours(Width, Height)
                         .Where(neighbour => seenCells.All(t => t != neighbour))
                         .Where(exceptCondition))
            {
                Cells[neighbour.X, neighbour.Y].Open();

                seenCells.Add(neighbour);

                if (shouldOpenCondition(neighbour))
                {
                    nextCells.Enqueue(neighbour);
                }
            }
        }

        ClosedCellsCount--;

        Cells[point.X, point.Y].Open();
    }

    private void PutMinedCells(Point exceptPoint, int seed)
    {
        var exceptNumber = exceptPoint.GetFlatCoordinate(Width);

        var possibleCoordinates = Enumerable.Range(0, Width * Height).ToList();
        possibleCoordinates.RemoveAt(exceptNumber);

        if (!possibleCoordinates.Any())
        {
            return;
        }

        var random = new Random(seed);

        for (var j = 0; j < NumberOfMines; j++)
        {
            var i = random.Next(0, possibleCoordinates.Count);

            var mineIndex = possibleCoordinates[i];

            possibleCoordinates.RemoveAt(i);

            var point = Point.GetPoint(mineIndex, Width);


            Cells[point.X, point.Y].IsMined = true;
        }
    }

    private void InitNumberOfCells()
    {
        for (var i = 0; i < Height; i++)
        {
            for (var j = 0; j < Width; j++)
            {
                var numberOfMines = new Point(i, j).GetNeighbours(Width, Height).Count(t => Cells[t.X, t.Y].IsMined);

                Cells[i, j].NumberOfMinesAround = numberOfMines;
            }
        }
    }
}