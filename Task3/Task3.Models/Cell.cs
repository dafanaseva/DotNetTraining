namespace Task3.Models;

internal sealed record Cell
{
    public delegate void StateHandler();

    public event StateHandler? NotifyStateHasChanged;
    public bool IsMined { get; private set; }
    public bool IsOpen { get; private set; }
    public bool IsFlagged { get; private set; }

    public List<Cell> Neighbours = new();

    public void Open()
    {
        IsOpen = true;

        NotifyStateHasChanged?.Invoke();
    }

    public void SwitchFlag()
    {
        IsFlagged = !IsFlagged;

        NotifyStateHasChanged?.Invoke();
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