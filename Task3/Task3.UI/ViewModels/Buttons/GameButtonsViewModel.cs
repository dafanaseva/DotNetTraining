using System.Collections.ObjectModel;
using System.Windows;
using Task3.Models.GameCell;
using Task3.Models.GameProcess;

namespace Task3.UI.ViewModels.Buttons;

internal sealed class GameButtonsViewModel
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public ObservableCollection<GameButtonViewModel> Buttons { get; }

    public delegate void RefreshHandler(Cell[,] cells, CellViewModel.ClickHandler clickHandler);
    public event RefreshHandler? NotifyBoardRefreshed;

    public GameButtonsViewModel(Game game, RefreshHandler refreshHandler)
    {
        NotifyBoardRefreshed += refreshHandler;
        Buttons = new ObservableCollection<GameButtonViewModel>
        {
            new("New game", () =>
            {
                var cells = game.StartNew();
                NotifyBoardRefreshed?.Invoke(cells, game.OpenCell);
            }),
            new("Exit", () =>
            {
                // Todo: need to find out more safe way to exit
                Application.Current.Shutdown();
            })
        };
    }
}