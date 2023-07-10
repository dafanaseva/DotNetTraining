using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Task3.Models.GameCell;
using Task3.UI.Commands;
using Task3.UI.ViewModels.Buttons;

namespace Task3.UI.ViewModels;

internal sealed class CellViewModel : INotifyPropertyChanged
{
    private readonly Cell _cell;
    private string _value;

    // ReSharper disable once MemberCanBePrivate.Global
    public string Value
    {
        // ReSharper disable once UnusedMember.Global
        get => _value;
        set
        {
            _value = value;
            OnPropertyChanged();
        }
    }

    public delegate void ClickHandler(Point point);
    public event ClickHandler? NotifyCellIsClicked;

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public CellButtonViewModel Button { get;}


    // ReSharper disable once MemberCanBePrivate.Global
    public event PropertyChangedEventHandler? PropertyChanged;

    public CellViewModel(Cell cell, Point point)
    {
        Debug.Assert(!ReferenceEquals(cell, null));

        _cell = cell;
        _cell.NotifyCellStateChanged += UpdateValue;

        _value = _cell.GetImage();

        Button = new CellButtonViewModel(
            new ClickOnButtonCommand(() => NotifyCellIsClicked?.Invoke(point), CanExecuteCommand),
            new ClickOnButtonCommand(() => _cell.SwitchFlag(), CanExecuteCommand));
    }

    private bool CanExecuteCommand()
    {
        return !_cell.IsOpen;
    }

    private void UpdateValue()
    {
        Value = _cell.GetImage();
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}