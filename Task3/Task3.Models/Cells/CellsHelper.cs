namespace Task3.Models.Cells;

internal static class CellsHelper
{
    public static int GetNumberOfMines(this Cell cell)
    {
        return cell.Neighbours.Count(neighbour => neighbour.IsMined);
    }

    public static bool IsAnyNeighbourMined(this Cell cell)
    {
        return cell.Neighbours.Any(neighbour => neighbour.IsMined);
    }
}