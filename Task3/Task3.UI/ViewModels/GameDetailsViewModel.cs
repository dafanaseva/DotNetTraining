using System;
using System.Collections.ObjectModel;
using Task3.Models.GameProcess;

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

        Details = new ObservableCollection<string>();

        _game.NotifyGameEnded += AddGameStatusDetail;
    }

    private void AddGameStatusDetail()
    {
        Details.Clear();

        Details.Add($"Game ended: {_game.GameState}");
        Details.Add($"The highest score: {GetHighScore()}");
    }

    private string GetHighScore()
    {
        var highScore = _game.HighScore();

        return highScore == TimeSpan.MaxValue ? "-" : highScore.ToString("g");
    }
}