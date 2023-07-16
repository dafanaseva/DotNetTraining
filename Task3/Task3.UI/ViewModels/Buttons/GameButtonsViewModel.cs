using System.Collections.ObjectModel;
using Task3.Models.GameProcess;

namespace Task3.UI.ViewModels.Buttons;

internal sealed class GameButtonsViewModel
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public ObservableCollection<GameButtonViewModel> Buttons { get; }

    public GameButtonsViewModel(Game game)
    {
        Buttons = new ObservableCollection<GameButtonViewModel>
        {
            new("New game", () =>
            {
                game.StartNew();

            }),
            new("Exit", () =>
            {
                game.IsCancelled = true;
                //todo:
            })
        };
    }
}