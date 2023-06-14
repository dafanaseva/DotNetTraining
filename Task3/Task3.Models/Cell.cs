namespace Task3.Models;

internal sealed record Cell
{
    public int? NumberOfMines { get; set; }
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

    public bool HasMinedNeighbours()
    {
        return NumberOfMines > 0;
    }

    public string GetValue()
    {
        if (!IsOpen)
        {
            return IsFlagged ? "#" : string.Empty;
        }

        if (IsFlagged)
        {
            //todo: move to consts
            return "#";
        }

        var numberOfMines = NumberOfMines == 0 ? string.Empty : NumberOfMines?.ToString() ?? string.Empty;

        return IsMined ? "X" : NumberOfMines?.ToString() ?? numberOfMines;
    }
}