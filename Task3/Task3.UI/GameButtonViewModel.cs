using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Task3.UI;

//todo: reuse button in other places
internal sealed class GameButtonViewModel : INotifyPropertyChanged
{

    private readonly Action _action;
    private ClickOnButtonCommand? _clickOnCellCommand;

    public GameButtonViewModel(string text, Action action)
    {
        Text = text;
        _action = action;
    }

    public string Text { get; }

    public ClickOnButtonCommand Command
    {
        get
        {
            return _clickOnCellCommand ??= new ClickOnButtonCommand(() => _action(), () => true);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}