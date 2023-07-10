using System;
using Task3.Models.GameCell;

namespace Task3.UI;

internal static class CellHelper
{
    public static string GetValue(this Cell cell)
    {
        var state = cell.GetState();
        return state switch
        {
            CellState.Unknown => string.Empty,
            CellState.Safe => GetSafeValue(cell),
            CellState.Mine => "X",
            CellState.Flag => "?",
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
        };
    }

    private static string GetSafeValue(Cell cell)
    {
        return cell.NumberOfMinesAround > 0 ? cell.NumberOfMinesAround.ToString() : string.Empty;
    }
}