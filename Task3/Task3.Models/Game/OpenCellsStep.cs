using Task3.Models.Cells;

namespace Task3.Models.Game;

internal sealed class OpenCellsStep
{
    private readonly GameBoard _gameBoard;

    public int ClosedCellsCount { get; private set; }

    public OpenCellsStep(GameBoard gameBoard)
    {
        _gameBoard = gameBoard;

        ClosedCellsCount = gameBoard.Height * gameBoard.Width;
    }

    public void OpenNotMinedCells(Point point)
    {
        OpenCells(point, neighbour => !neighbour.IsMined, neighbour => neighbour.IsAnyNeighbourMined());
    }

    public void OpenAllCells(Point point)
    {
        OpenCells(point, _ => true, _ => false);
    }

    private void OpenCells(Point point, Func<Cell, bool> exceptCondition, Func<Cell, bool> skipCondition)
    {
        var nextCells = new Queue<Cell>();
        var seenCells = new HashSet<Cell>();

        nextCells.Enqueue(_gameBoard[point.X, point.Y]);
        seenCells.Add(_gameBoard[point.X, point.Y]);

        while (nextCells.Any())
        {
            var node = nextCells.Dequeue();

            foreach (var neighbour in node.Neighbours
                         .Where(neighbour => seenCells.All(t => t != neighbour))
                         .Where(exceptCondition))
            {
                neighbour.Open();
                seenCells.Add(neighbour);

                if (skipCondition(neighbour))
                {
                    continue;
                }

                nextCells.Enqueue(neighbour);
            }
        }

        ClosedCellsCount--;

        _gameBoard[point.X, point.Y].Open();
    }
}