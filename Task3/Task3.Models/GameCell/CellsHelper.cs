using Task3.Models.GameBoard;

namespace Task3.Models.GameCell;

internal static class CellsHelper
{
    public static Width GetWidth(this Cell[,] cells)
    {
        return new Width(cells.GetLength(0));
    }

    public static Height GetHeight(this Cell[,] cells)
    {
        return new Height(cells.GetLength(0));
    }
}