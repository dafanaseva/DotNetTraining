namespace Task3.Models;

internal sealed record Cell
{
    private const string FlagSymbol = "?";
    private const string MineSymbol = "X";

    public int? NumberOfMines { get; private set; }
    public bool IsMined { get; set; }
    public bool IsOpen { get; private set; }
    public bool IsFlagged { get; private set; }

    public void Open()
    {
        IsOpen = true;
    }

    public void SwitchFlag()
    {
        IsFlagged = !IsFlagged;
    }

    public void SetNumberOfMines(int number)
    {
        NegativeArgumentException.ThrowIfLessThenNull(number);

        NumberOfMines = number;
    }

    public bool HasMinedNeighbours()
    {
        return NumberOfMines > 0;
    }

    public string GetState()
    {
        if (!IsOpen)
        {
            return IsFlagged ? FlagSymbol : string.Empty;
        }

        var numberOfMines = !HasMinedNeighbours() ? string.Empty : NumberOfMines?.ToString() ?? string.Empty;

        return IsMined ? MineSymbol : numberOfMines;
    }
}