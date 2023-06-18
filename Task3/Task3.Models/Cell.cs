namespace Task3.Models;

internal sealed record Cell
{
    public bool IsMined { get; set; }
    public bool IsOpen { get; private set; }
    public bool IsFlagged { get; private set; }
    public int NumberOfMinedNeighbours { get; private set; }

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

        NumberOfMinedNeighbours = number;
    }

    public bool IsAnyNeighbourMined()
    {
        return NumberOfMinedNeighbours > 0;
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