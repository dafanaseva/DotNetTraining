using Task3.Models.GameCell;

namespace Task3.Models.GameBoard;

internal sealed partial class Board
{
    private int _openCellsCount;

    public bool AreAllOpened()
    {
        return _openCellsCount - _countOfMines == 0;
    }

    public void OpenNotMinedCells(Point point)
    {
        OpenCells(
            point: point,
            exceptCondition: neighbour => !Cells[neighbour.X, neighbour.Y].IsMined,
            shouldOpenCondition: neighbour => Cells[neighbour.X, neighbour.Y].NumberOfMinesAround == 0);
    }

    public void OpenAllCells(Point point)
    {
        OpenCells(
            point: point,
            exceptCondition: _ => true,
            shouldOpenCondition: _ => true);
    }

    //todo: update flagged cells
    private void OpenCells(Point point, Func<Point, bool> exceptCondition, Func<Point, bool> shouldOpenCondition)
    {
        var nextCells = new Queue<Point>();
        var seenCells = new HashSet<Point>();

        nextCells.Enqueue(point);
        seenCells.Add(point);

        while (nextCells.Any())
        {
            var node = nextCells.Dequeue();

            foreach (var neighbour in GetNeighbours(node)
                         .Where(neighbour => seenCells.All(t => t != neighbour))
                         .Where(x => !IsBorder(x))
                         .Where(exceptCondition))
            {
                Cells[neighbour.X, neighbour.Y].Open();

                seenCells.Add(neighbour);

                if (shouldOpenCondition(neighbour))
                {
                    nextCells.Enqueue(neighbour);
                }
            }
        }

        _openCellsCount++;

        Cells[point.X, point.Y].Open();
    }

    private bool IsBorder(Point point)
    {
        var fullWidth = Border.GetFullLength(Width);
        var fullHeight = Border.GetFullLength(Height);

        var (x, y) = point;

        return x <= 0 || y <= 0 || x >= fullWidth - 1 || y >= fullHeight - 1;
    }
}