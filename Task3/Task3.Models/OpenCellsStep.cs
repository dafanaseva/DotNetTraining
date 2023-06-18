namespace Task3.Models;

internal sealed class OpenCellsStep
{
    private readonly GameBoard _gameBoard;

    public OpenCellsStep(GameBoard gameBoard)
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

            foreach (var neighbour in _gameBoard.GetNeighbours(node.X, node.Y))
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

                if(_gameBoard[neighbour.X, neighbour.Y].IsAnyNeighbourMined())
                {
                    continue;
                }

                nextCells.Enqueue(neighbour);
            }
        }

        _gameBoard[x, y].Open();
    }
}