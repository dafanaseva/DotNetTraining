namespace Task3.Models;

internal sealed record Cell
{
    public bool IsMined { get; private set; }
    public bool IsOpen { get; private set; }
    public bool IsFlagged { get; private set; }

    public List<Cell> Neighbours = new();

    public void Open()
    {
        IsOpen = true;
    }

    public void SwitchFlag()
    {
        IsFlagged = !IsFlagged;
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