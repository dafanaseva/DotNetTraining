using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task3.Models;

namespace Task3.UI;

internal sealed class CellViewModel : INotifyPropertyChanged
{
    private readonly Cell _cell;

    private ClickOnCellCommand? _clickOnCellCommand;
    private ClickOnCellCommand? _rightClickOnCellCommand;

    private string _state;
    private bool _canSelect = true;

    private readonly Point _coordinate;

    public delegate void CellHandler(Point coordinate);
    public delegate void CellFlagHandler(Point coordinate);

    public event CellHandler? NotifyCellIsClicked;
    public event CellFlagHandler? NotifyCellIsRightClicked;

    public ClickOnCellCommand ClickOnCellCommand
    {
        get
        {
            return _clickOnCellCommand ??=
                new ClickOnCellCommand(() => NotifyCellIsClicked?.Invoke(_coordinate), CanExecute);
        }
    }

    public ClickOnCellCommand RightClickOnCellCommand
    {
        get
        {
            return _rightClickOnCellCommand ??= new ClickOnCellCommand(() =>
                {
                    NotifyCellIsRightClicked?.Invoke(_coordinate);

                    State = _cell.GetValue();
                },
                CanExecute);
        }
    }

    public string State
    {
        get => _state;
        set
        {
            _state = value;
            OnPropertyChanged();
        }
    }

    public bool CanSelect
    {
        get => _canSelect;
        set
        {
            _canSelect = value;
            OnPropertyChanged();
        }
    }

    public CellViewModel(Cell cell, int x, int y)
    {
        _cell = cell;
        _state = cell.GetValue();

        _coordinate = new Point(x, y);
    }

    public void Update()
    {
        State = _cell.GetValue();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool CanExecute()
    {
        return !_cell.IsOpen;
    }
}