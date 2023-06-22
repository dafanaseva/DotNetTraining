using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Task3.Models;

namespace Task3.UI;

internal sealed class CellViewModel : INotifyPropertyChanged
{
    private readonly Cell _cell;
    private readonly Point _position;

    private ClickOnCellCommand? _clickOnCellCommand;
    private ClickOnCellCommand? _rightClickOnCellCommand;

    private string _value;
    private bool _canSelect = true;

    public string Value
    {
        get => _value;
        set
        {
            _value = value;
            OnPropertyChanged();
        }
    }

    // ReSharper disable once UnusedMember.Global
    public bool CanSelect
    {
        get => _canSelect;
        set
        {
            _canSelect = value;
            OnPropertyChanged();
        }
    }

    public delegate void ClickHandler(Point point);

    public event ClickHandler? NotifyCellIsClicked;

    public event PropertyChangedEventHandler? PropertyChanged;

    // ReSharper disable once UnusedMember.Global
    public ClickOnCellCommand ClickOnCell
    {
        get
        {
            return _clickOnCellCommand ??= new ClickOnCellCommand(() =>
                {
                    NotifyCellIsClicked?.Invoke(_position);
                },
                CanExecuteCommand);
        }
    }

    // ReSharper disable once UnusedMember.Global
    public ClickOnCellCommand RightClickOnCell
    {
        get
        {
            return _rightClickOnCellCommand ??= new ClickOnCellCommand(() =>
                {
                    _cell.SwitchFlag();
                },
                CanExecuteCommand);
        }
    }

    public CellViewModel(Cell cell, int x, int y)
    {
        Debug.Assert(!ReferenceEquals(cell, null), "cell != null ");

        _cell = cell;
        _cell.NotifyStateHasChanged += UpdateValue;

        _value = _cell.GetValue();
        _position = new Point(x, y);
    }

    private bool CanExecuteCommand()
    {
        return !_cell.IsOpen;
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void UpdateValue()
    {
        Value = _cell.GetValue();
    }
}