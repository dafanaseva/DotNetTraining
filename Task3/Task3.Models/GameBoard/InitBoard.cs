using Task3.Models.GameCell;

namespace Task3.Models.GameBoard;

internal sealed partial class Board
{
    public void InitializeCells(Point point)
    {
        if (_isInitialized)
        {
            return;
        }

        PutMinedCells(point, _seed);
        InitNumberOfCells();

        _isInitialized = true;
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

        for (var j = 0; j < _countOfMines; j++)
        {
            var i = random.Next(0, possibleCoordinates.Count);

            var mineIndex = possibleCoordinates[i];

            possibleCoordinates.RemoveAt(i);

            var point = Point.GetPoint(mineIndex, Width);

            Cells[point.X, point.Y] = Cells[point.X, point.Y] with { IsMined = true };
        }
    }

    private void InitNumberOfCells()
    {
        for (var i = Border.Width; i < Height + Border.Width; i++)
        {
            for (var j = Border.Width; j < Width + Border.Width; j++)
            {
                var numberOfMines = GetNeighbours(new Point(i, j)).Count(t => Cells[t.X, t.Y].IsMined);

                Cells[i, j] = Cells[i, j] with { NumberOfMinesAround = numberOfMines };
            }
        }
    }
}