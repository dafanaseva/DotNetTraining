using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task3.Models.Game;

namespace Task3.UI;

internal sealed class GameDetailsViewModel : INotifyPropertyChanged
{
    private readonly Game _game;

    public ObservableCollection<string> Details { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

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

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}