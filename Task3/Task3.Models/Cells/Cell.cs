namespace Task3.Models.Cells;

internal sealed record Cell
{
    public bool IsMined { get; private set; }
    public bool IsOpen { get; private set; }
    public bool IsFlagged { get; private set; }


    public List<Cell> Neighbours = new();

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

    public void SetMine()
    {
        IsMined = true;
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