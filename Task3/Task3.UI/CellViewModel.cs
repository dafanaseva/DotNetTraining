using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task3.Models;

namespace Task3.UI;

internal sealed class CellViewModel : INotifyPropertyChanged
{
    private readonly Cell _cell;
    private readonly Point _point;

    private string _value;
    private bool _canSelect;

    public string Value
    {
        get => _value;
        set
        {
            _value = value;
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

    public ClickOnCellCommand ClickOnCell
    {
        get
        {
            return _clickOnCellCommand ??=
                new ClickOnCellCommand(() => NotifyCellIsClicked?.Invoke(_point), CanExecuteCommand);
        }
    }

    public ClickOnCellCommand RightClickOnCell
    {
        get
        {
            return _rightClickOnCellCommand ??= new ClickOnCellCommand(() =>
                {
                    NotifyCellIsRightClicked?.Invoke(_point);

                    Value = GetValue();
                },
                CanExecuteCommand);
        }
    }

    public CellViewModel(Cell cell, int x, int y)
    {
        _cell = cell;
        _point = new Point(x, y);

        _canSelect = true;
        _value = GetValue();
    }

    public void UpdateState()
    {
        Value = GetValue();
    }

    private bool CanExecuteCommand()
    {
        return !_cell.IsOpen;
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string GetValue()
    {
        var cellState = _cell.GetState();

        var numberOfMinesSymbol = _cell.NumberOfMinedNeighbours == 0 ? string.Empty : _cell.NumberOfMinedNeighbours.ToString();

        return cellState switch
        {
            CellState.Safe => _cell.IsOpen ? numberOfMinesSymbol : string.Empty,
            CellState.Mine => _cell.IsOpen ? "X" : string.Empty,
            CellState.Flag => "?",
            _ => throw new ArgumentOutOfRangeException(nameof(cellState), cellState, null)
        };
    }
}