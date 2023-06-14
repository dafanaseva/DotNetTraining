namespace Task3.Models;

internal sealed class OpenCellStep
{
    private const int MaxNeighbourIndex = 2;
    private const int MinNeighbourIndex = -1;

    private readonly GameBoard _gameBoard;

    public OpenCellStep(GameBoard gameBoard)
    {
        _gameBoard = gameBoard;
    }

    public void OpenCells(int x, int y)
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

                if(_gameBoard[neighbour.X, neighbour.Y].IsMined)
                {
                    continue;
                }

                _gameBoard[neighbour.X, neighbour.Y].Open();
                seenCells.Add(neighbour);

                if(_gameBoard[neighbour.X, neighbour.Y].HasMinedNeighbours())
                {
                    continue;
                }

                nextCells.Enqueue(neighbour);
            }
        }

        _gameBoard[x, y].Open();
    }

    private List<Point> GetNeighbours(int x, int y)
    {
        var result = new List<Point>();
        for (var i = MinNeighbourIndex; i < MaxNeighbourIndex; i++)
        {
            for (var j = MinNeighbourIndex; j < MaxNeighbourIndex; j++)
            {
                var neighborX = x + i;
                if (neighborX < 0 || neighborX >= _gameBoard.Width)
                {
                    continue;
                }

                var neighborY = y + j;
                if (neighborY < 0 || neighborY >= _gameBoard.Height)
                {
                    continue;
                }

                result.Add(new Point(neighborX, neighborY));
            }
        }

        return result;
    }
}