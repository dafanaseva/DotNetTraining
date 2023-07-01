using System;
using Task3.UI.Commands;

namespace Task3.UI.ViewModels.Buttons;

internal sealed class GameButtonViewModel
{
    private readonly Action _action;
    private ClickOnButtonCommand? _clickOnCellCommand;

    public GameButtonViewModel(string text, Action action)
    {
        Text = text;
        _action = action;
    }

    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public string Text { get; }

    // ReSharper disable once UnusedMember.Global
    public ClickOnButtonCommand Command
    {
        get
        {
            return _clickOnCellCommand ??= new ClickOnButtonCommand(() => _action(), () => true);
        }
    }
}