using System.Collections.Generic;
using Task3.Models.Game;

namespace Task3.UI.ViewModels.Buttons;

internal sealed class GameButtonsViewModel
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public List<GameButtonViewModel> Buttons { get; }

    public GameButtonsViewModel(Game game)
    {
        Buttons = new List<GameButtonViewModel>
        {
            new("New game", game.NewGame),
            new("High score", () => game.HighScore()),
            new("Exit", game.ExitGame),
            new("About", () => Game.About())
        };
    }
}