namespace Task3.Models;

internal sealed class InitializeBoardStep
{
    private readonly int _totalNumberOfMines;

    private readonly int _width;
    private readonly int _height;

    private readonly GameBoard _gameBoard;

    private bool _isInitialized;

    public InitializeBoardStep(GameBoard gameBoard, int totalNumberOfMines)
    {
        _gameBoard = gameBoard;

        _totalNumberOfMines = totalNumberOfMines;

        _height = _gameBoard.Height;
        _width = _gameBoard.Width;

        _isInitialized = false;
    }

    public void TryInitializeCells(int x, int y)
    {
        if (_isInitialized)
        {
            return;
        }

        PutMinedCells(x,y);
        CountMinedCells();

        _isInitialized = true;
    }

    private void PutMinedCells(int exceptX, int exceptY)
    {
        var totalElements = _width * _height;

        var exceptNumber = exceptX * _width + exceptY;

        var possibleCoordinates = Enumerable.Range(0, totalElements).ToList();
        possibleCoordinates.RemoveAt(exceptNumber);

        totalElements--;

        _gameBoard[exceptX, exceptY].IsMined = false;

        var random = new Random();

        for (var j = 0; j < _totalNumberOfMines; j++)
        {
            var i = random.Next(0, totalElements);

            var mineIndex = possibleCoordinates[i];

            possibleCoordinates.RemoveAt(i);
            totalElements--;

            var (x, y) = Point.GetPoint(mineIndex, _width);

            _gameBoard[x, y].IsMined = true;
        }

        foreach (var notMinedCoordinate in possibleCoordinates)
        {
            var (x, y) = Point.GetPoint(notMinedCoordinate, _width);

            _gameBoard[x, y].IsMined = false;
        }
    }

    private void CountMinedCells()
    {
        for (var i = 0; i < _width; i++)
        {
            for (var j = 0; j < _height; j++)
            {
                var neighbours = _gameBoard.GetNeighbours(i, j);

                var numberOfMines = neighbours.Count(neighbour => _gameBoard[neighbour.X, neighbour.Y].IsMined);

                _gameBoard[i, j].NumberOfMines = numberOfMines;
            }
        }
    }
}