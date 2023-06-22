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
        var nextCells = new Queue<Cell>();
        var seenCells = new HashSet<Cell>();

        nextCells.Enqueue(_gameBoard[x, y]);
        seenCells.Add(_gameBoard[x, y]);

        while (nextCells.Any())
        {
            var node = nextCells.Dequeue();

            foreach (var neighbour in node.Neighbours
                         .Where(neighbour => seenCells.All(t => t != neighbour))
                         .Where(neighbour => !neighbour.IsMined))
            {
                neighbour.Open();
                seenCells.Add(neighbour);

                if (neighbour.IsAnyNeighbourMined())
                {
                    continue;
                }

                nextCells.Enqueue(neighbour);
            }
        }

        _gameBoard[x, y].Open();
    }
}