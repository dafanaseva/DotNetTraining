using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task3.Models.Game;

namespace Task3.UI;

internal sealed class GameButtonsViewModel : INotifyPropertyChanged
{
    private readonly Game _game;
    public List<GameButtonViewModel> Buttons { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public GameButtonsViewModel(Game game)
    {
        _game = game;

        Buttons = new List<GameButtonViewModel>
        {
            new("New game", () => _game.NewGame()),
            new("High score", () => _game.HighScore()),
            new("Exit", () => _game.ExitGame()),
            new("About", () => Game.About())
        };
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}