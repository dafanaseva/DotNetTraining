using System.Collections.ObjectModel;
using Task3.Models.Game;

namespace Task3.UI.ViewModels;

internal sealed class GameDetailsViewModel
{
    private readonly Game _game;

    // ReSharper disable once CollectionNeverQueried.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public ObservableCollection<string> Details { get; }

    public GameDetailsViewModel(Game game)
    {
        _game = game;

        Details = new ObservableCollection<string>
        {
            $"The highest score: {game.HighScore()}",
            $"About: {Game.About()}"
        };

        _game.NotifyGameEnded += AddGameStatusDetail;
    }

    private void AddGameStatusDetail()
    {
        Details.Add($"Game ended: {_game.GameState}");
    }
}