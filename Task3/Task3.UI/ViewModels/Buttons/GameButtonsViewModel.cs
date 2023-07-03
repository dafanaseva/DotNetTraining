using System.Collections.Generic;
using System.Collections.Immutable;
using Task3.Models.GameProcess;

namespace Task3.UI.ViewModels.Buttons;

internal sealed class GameButtonsViewModel
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public ImmutableArray<GameButtonViewModel> Buttons { get; }

    public GameButtonsViewModel(Game game)
    {
        Buttons = new ImmutableArray<GameButtonViewModel>
        {
            new("New game", game.NewGame),
            new("High score", () => game.HighScore()),
            new("Exit", game.ExitGame),
            new("About", () => Game.About())
        };
    }
}