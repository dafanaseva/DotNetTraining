using System;
using Task3.Models.GameCell;

namespace Task3.UI;

internal static class CellHelper
{
    //TODO: show image
    public static string GetImage(this Cell cell)
    {
        var cellState = cell.GetState();

        var numberOfMinesSymbol = cell.NumberOfMinesAround > 0 ? cell.NumberOfMinesAround.ToString() : string.Empty;

        return GetValue(cellState, cell.IsOpen, numberOfMinesSymbol);
    }

    private static string GetValue(CellState state, bool isOpen, string numberOfMinesSymbol)
    {
        return state switch
        {
            CellState.Safe => isOpen ? numberOfMinesSymbol : string.Empty,
            CellState.Mine => isOpen ? "X" : string.Empty,
            CellState.Flag => isOpen ? numberOfMinesSymbol : "?",
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
        };
    }
}