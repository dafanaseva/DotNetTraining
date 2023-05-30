namespace Task3.Models;

internal sealed class GameBoard
{
    private readonly int _width;
    private readonly int _height;
    private readonly int _totalNumberOfMines;
    private bool _firstClick;

    public Cell[,] Cells { get; }

    public GameBoard(int width, int height, int totalNumberOfMines)
    {
        _width = width;
        _height = height;
        _totalNumberOfMines = totalNumberOfMines;
        _firstClick = true;

        Cells = new Cell[width, height];
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                Cells[i, j] = new Cell(IsMined: false);
            }
        }
    }

    public void OpenCell(int x, int y)
    {
        if (_firstClick)
        {
            InitField(x, y);
            InitCountValuesOfNeighbors(x, y);

            _firstClick = false;
        }

        OpenNotMinedNeighbours(x, y);
    }

    private void InitField(int exceptX, int exceptY)
    {
        var totalElements = _width * _height;

        var exceptNumber = exceptX * _width + exceptY;

        var possibleCoordinates = Enumerable.Range(0, totalElements).ToList();
        possibleCoordinates.RemoveAt(exceptNumber);
        totalElements--;

        Cells[exceptX, exceptY].IsMined = false;

        var random = new Random();

        for (var j = 0; j < _totalNumberOfMines; j++)
        {
            var i = random.Next(0, totalElements);

            var mineIndex = possibleCoordinates[i];

            possibleCoordinates.RemoveAt(i);
            totalElements--;

            var (x, y) = GetCoordinate(mineIndex);

            Cells[x, y].IsMined = true;
        }

        foreach (var notMinedCoordinate in possibleCoordinates)
        {
            var (x, y) = GetCoordinate(notMinedCoordinate);

            Cells[x, y].IsMined = false;
        }
    }

    private void InitCountValuesOfNeighbors(int x, int y)
    {
        if (Cells[x, y].NumberOfMines != null)
        {
            return;
        }

        var numberOfMines = 0;

        for (var i = -1; i < 2; i++)
        {
            for (var j = -1; j < 2; j++)
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

                if (Cells[neighborX, neighborY].IsMined)
                {
                    numberOfMines++;
                }

                Cells[x, y].NumberOfMines = numberOfMines;

                InitCountValuesOfNeighbors(neighborX, neighborY);
            }
        }
    }

    private void OpenNotMinedNeighbours(int x, int y)
    {
        var nextCells = new Queue<Point>();
        var seenCells = new HashSet<Point>();

        nextCells.Enqueue(new Point(x, y));
        seenCells.Add(new Point(x, y));

        while (nextCells.Any())
        {
            var node = nextCells.Dequeue();

            foreach (var neighbour in GetNeighbours(node.X, node.Y))
            {
                if (seenCells.Any(t => t == neighbour))
                {
                    continue;
                }

                if (Cells[neighbour.X, neighbour.Y].IsMined)
                {
                    continue;
                }

                Cells[neighbour.X, neighbour.Y].IsOpen = true;
                seenCells.Add(neighbour);

                if (Cells[neighbour.X, neighbour.Y].NumberOfMines > 0)
                {
                    continue;
                }

                nextCells.Enqueue(neighbour);
            }
        }

        Cells[x, y].IsOpen = true;
    }

    private List<Point> GetNeighbours(int x, int y)
    {
        var result = new List<Point>();
        for (var i = -1; i < 2; i++)
        {
            for (var j = -1; j < 2; j++)
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

                result.Add(new Point(neighborX, neighborY));
            }
        }

        return result;
    }

    private (int, int) GetCoordinate(int numberOfCell)
    {
        var x = numberOfCell / _width;
        var y = numberOfCell % _width;
        return (x, y);
    }
}