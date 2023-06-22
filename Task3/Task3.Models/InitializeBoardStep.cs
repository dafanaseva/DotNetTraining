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

        LessThenZeroArgumentException.ThrowIfLessThenZero(totalNumberOfMines);
        _totalNumberOfMines = totalNumberOfMines;

        _height = _gameBoard.Height;
        _width = _gameBoard.Width;

        _isInitialized = false;
    }

    public void InitializeCells(int x, int y)
    {
        if (_isInitialized)
        {
            return;
        }

        PutMinedCells(x,y);

        _isInitialized = true;
    }

    private void PutMinedCells(int exceptX, int exceptY)
    {
        var exceptNumber = exceptX * _width + exceptY;

        var possibleCoordinates = Enumerable.Range(0, _width * _height).ToList();
        possibleCoordinates.RemoveAt(exceptNumber);

        if (!possibleCoordinates.Any())
        {
            return;
        }

        var random = new Random();

        for (var j = 0; j < _totalNumberOfMines; j++)
        {
            var i = random.Next(0, possibleCoordinates.Count);

            var mineIndex = possibleCoordinates[i];

            possibleCoordinates.RemoveAt(i);

            var (x, y) = Point.GetPoint(mineIndex, _width);

            _gameBoard[x, y].SetMine();
        }
    }
}