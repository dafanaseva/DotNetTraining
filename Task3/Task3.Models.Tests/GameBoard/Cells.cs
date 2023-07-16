using Task3.Models.GameCell;

namespace Task3.Tests.GameBoard;

internal static class Cells
{
    public static Cell MinedCell = new()
    {
        IsMined = true
    };

    public static Cell NotMinedCell = new();

}