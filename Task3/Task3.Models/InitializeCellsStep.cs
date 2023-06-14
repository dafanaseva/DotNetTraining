namespace Task3.Models;

internal sealed class InitializeCellsStep
{
    private readonly int _totalNumberOfMines;

    private const int MaxNeighbourIndex = 2;
    private const int MinNeighbourIndex = -1;

    private readonly int _width;
    private readonly int _height;

    private readonly GameBoard _gameBoard;

    private bool _isInitialized;

    public InitializeCellsStep(GameBoard gameBoard, int totalNumberOfMines)
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

        InitField(x,y);
        InitCountValuesOfNeighbors(x, y);

        _isInitialized = true;
    }

    private void InitField(int exceptX, int exceptY)
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

            var (x, y) = GetCoordinate(mineIndex);

            _gameBoard[x, y].IsMined = true;
        }

        foreach (var notMinedCoordinate in possibleCoordinates)
        {
            var (x, y) = GetCoordinate(notMinedCoordinate);

            _gameBoard[x, y].IsMined = false;
        }
    }

    private void InitCountValuesOfNeighbors( int x, int y)
    {
        if (_gameBoard[x, y].NumberOfMines != null)
        {
            return;
        }

        var numberOfMines = 0;

        for (var i = MinNeighbourIndex; i < MaxNeighbourIndex; i++)
        {
            for (var j = MinNeighbourIndex; j < MaxNeighbourIndex; j++)
            {
                var neighborX = x + i;
                if (neighborX < 0 || neighborX >= _width)
                {
                    continue;
                }

                var neighborY = y + j;
                if (neighborY < 0 || neighborY >= _height)
                {
                    continue;
                }

                if (_gameBoard[neighborX, neighborY].IsMined)
                {
                    numberOfMines++;
                }

                _gameBoard[x, y].NumberOfMines = numberOfMines;

                InitCountValuesOfNeighbors(neighborX, neighborY);
            }
        }
    }

    private Point GetCoordinate(int numberOfCell)
    {
        var x = numberOfCell / _width;
        var y = numberOfCell % _width;

        return new Point(x, y);
    }
}