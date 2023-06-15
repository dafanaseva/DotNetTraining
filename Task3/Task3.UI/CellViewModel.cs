using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task3.Models;

namespace Task3.UI;

internal sealed class CellViewModel : INotifyPropertyChanged
{
    private readonly Cell _cell;
    private readonly Point _point;

    private string _state;
    private bool _canSelect;

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

    private ClickOnCellCommand? _clickOnCellCommand;
    private ClickOnCellCommand? _rightClickOnCellCommand;

    public delegate void ClickHandler(Point point);
    public delegate void RightClickHandler(Point point);

    public event ClickHandler? NotifyCellIsClicked;
    public event RightClickHandler? NotifyCellIsRightClicked;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ClickOnCellCommand ClickOnCellCommand
    {
        get
        {
            return _clickOnCellCommand ??=
                new ClickOnCellCommand(() => NotifyCellIsClicked?.Invoke(_point), CanExecuteCommand);
        }
    }

    public ClickOnCellCommand RightClickOnCellCommand
    {
        get
        {
            return _rightClickOnCellCommand ??= new ClickOnCellCommand(() =>
                {
                    NotifyCellIsRightClicked?.Invoke(_point);

                    State = _cell.GetState();
                },
                CanExecuteCommand);
        }
    }

    public CellViewModel(Cell cell, int x, int y)
    {
        _cell = cell;
        _point = new Point(x, y);

        _canSelect = true;
        _state = cell.GetState();
    }

    public void UpdateState()
    {
        State = _cell.GetState();
    }

    private bool CanExecuteCommand()
    {
        return !_cell.IsOpen;
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}