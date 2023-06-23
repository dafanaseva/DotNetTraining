using Task3.Models.Cells;
using Task3.Models.Exceptions;

namespace Task3.Models.Game;

internal sealed class InitializeBoardStep
{
    private readonly int _width;
    private readonly int _height;
    private readonly int _seed;

    private readonly GameBoard _gameBoard;

    public int TotalNumberOfMines { get; }

    private bool _isInitialized;

    public InitializeBoardStep(GameBoard gameBoard, int totalNumberOfMines, int seed)
    {
        _gameBoard = gameBoard;

        LessThenZeroArgumentException.ThrowIfLessThenZero(totalNumberOfMines);

        TotalNumberOfMines = totalNumberOfMines;

        _height = _gameBoard.Height;
        _width = _gameBoard.Width;
        _seed = seed;

        _isInitialized = false;
    }

    public void InitializeCells(Point point)
    {
        if (_isInitialized)
        {
            return;
        }

        PutMinedCells(point, _seed);

        _isInitialized = true;
    }

    private void PutMinedCells(Point exceptPoint, int seed)
    {
        // todo: maybe move to point?
        var exceptNumber = exceptPoint.X * _width + exceptPoint.Y;

        var possibleCoordinates = Enumerable.Range(0, _width * _height).ToList();
        possibleCoordinates.RemoveAt(exceptNumber);

        if (!possibleCoordinates.Any())
        {
            return;
        }

        var random = new Random(seed);

        for (var j = 0; j < TotalNumberOfMines; j++)
        {
            var i = random.Next(0, possibleCoordinates.Count);

            var mineIndex = possibleCoordinates[i];

            possibleCoordinates.RemoveAt(i);

            var (x, y) = Point.GetPoint(mineIndex, _width);

            _gameBoard[x, y].SetMine();
        }
    }
}