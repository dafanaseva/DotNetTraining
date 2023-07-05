using Task3.Models.GameCell;

namespace Task3.Models.GameBoard;

internal sealed partial class Board
{
    private const int BorderWidth = 1;
    public void InitializeCells(Point point)
    {
        //todo: check point is outside of bounds

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
        for (var i = BorderWidth; i < Height + BorderWidth; i++)
        {
            for (var j = BorderWidth; j < Width + BorderWidth; j++)
            {
                var numberOfMines = GetNeighbours(new Point(i, j)).Count(t => Cells[t.X, t.Y].IsMined);

                Cells[i, j].NumberOfMinesAround = numberOfMines;
            }
        }
    }
}