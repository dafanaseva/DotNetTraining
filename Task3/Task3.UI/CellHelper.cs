using System;
using Task3.Models.GameCell;

namespace Task3.UI;

internal static class CellHelper
{
    public static string GetValue(this Cell cell)
    {
        var cellState = cell.GetState();

        var numberOfMinesSymbol = cell.NumberOfMinesAround > 0 ? cell.NumberOfMinesAround.ToString() : string.Empty;

        //to do: use image instead of string
        return cellState switch
        {
            CellState.Safe => cell.IsOpen ? numberOfMinesSymbol : string.Empty,
            CellState.Mine => cell.IsOpen ? "X" : string.Empty,
            CellState.Flag => "?",
            _ => throw new ArgumentOutOfRangeException(nameof(cellState), cellState, null)
        };
    }
}