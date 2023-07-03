namespace Task3.Models.GameCell;

internal sealed record Cell
{
    public bool IsMined { get; init; }
    public bool IsOpen { get; private set; }
    public bool IsFlagged { get; private set; }
    public int NumberOfMinesAround { get; init; }

    public delegate void CellStateHandler();

    public event CellStateHandler? NotifyCellStateChanged;

    public void Open()
    {
        IsOpen = true;

        NotifyCellStateChanged?.Invoke();
    }

    public void SwitchFlag()
    {
        IsFlagged = !IsFlagged;

        NotifyCellStateChanged?.Invoke();
    }

    public CellState GetState()
    {
        if (IsFlagged)
        {
            return CellState.Flag;
        }

        return IsMined ? CellState.Mine : CellState.Safe;
    }
}
