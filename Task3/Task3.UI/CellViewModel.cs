using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task3.Models;

namespace Task3.UI;

internal sealed class CellViewModel : INotifyPropertyChanged
{
    private readonly Cell _cell;
    private ClickOnCellCommand? _clickOnCellCommand;

    private string _sign;
    private bool _canSelect = true;

    private readonly int _x;
    private readonly int _y;

    public delegate void CellHandler(int x, int y);

    public event CellHandler? Notify;

    // ReSharper disable once UnusedMember.Global
    public ClickOnCellCommand ClickOnCellCommand
    {
        get { return _clickOnCellCommand ??= new ClickOnCellCommand(() => Notify?.Invoke(_x, _y), () => _canSelect); }
    }

    public string Sign
    {
        // ReSharper disable once UnusedMember.Global
        get => _sign;
        set
        {
            _sign = value;
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
        _sign = cell.GetValue();
        _y = y;
        _x = x;
    }

    public void Update()
    {
        if (_cell.IsOpen)
        {
            Sign = _cell.GetValue();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}