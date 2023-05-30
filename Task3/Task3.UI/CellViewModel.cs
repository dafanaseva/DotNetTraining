using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task3.Models;

namespace Task3.UI;

internal sealed class CellViewModel : INotifyPropertyChanged
{
    private readonly Cell _cell;
    private ClickOnCellCommand? _clickOnCellCommand;

    private string _numberOfMines;
    private bool _canSelect = true;

    private readonly Point _coordinate;

    public delegate void CellHandler(Point coordinate);

    public event CellHandler? NotifyCellIsClicked;

    // ReSharper disable once UnusedMember.Global
    public ClickOnCellCommand ClickOnCellCommand
    {
        get { return _clickOnCellCommand ??= new ClickOnCellCommand(() => NotifyCellIsClicked?.Invoke(_coordinate), () => _canSelect); }
    }

    public string NumberOfMines
    {
        // ReSharper disable once UnusedMember.Global
        get => _numberOfMines;
        set
        {
            _numberOfMines = value;
            CanSelect = false;
            OnPropertyChanged();
        }
    }

    public bool CanSelect
    {
        // ReSharper disable once UnusedMember.Global
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
        _numberOfMines = cell.GetValue();

        _coordinate = new Point(x, y);
    }

    public void Update()
    {
        if (_cell.IsOpen)
        {
            NumberOfMines = _cell.GetValue();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}