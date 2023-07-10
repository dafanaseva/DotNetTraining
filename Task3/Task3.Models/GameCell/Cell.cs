using Task3.Models.Exceptions;

namespace Task3.Models.GameCell;

internal sealed record Cell
{
    private int _numberOfMinesAround;
    public bool IsMined { get; set; }
    public bool IsOpen { get; private set; }
    public bool IsFlagged { get; private set; }

    public int NumberOfMinesAround
    {
        get => _numberOfMinesAround;
        set
        {
            LessThenZeroArgumentException.ThrowIfLessThenZero(value);

            _numberOfMinesAround = value;
        }
    }

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
        if (!IsOpen)
        {
            return IsFlagged ? CellState.Flag : CellState.Unknown;
        }

        return IsMined ? CellState.Mine : CellState.Safe;
    }
}
