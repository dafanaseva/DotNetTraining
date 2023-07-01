using Task3.Models.Game;
using Task3.UI.ViewModels;
using Task3.UI.ViewModels.Buttons;

namespace Task3.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //todo: move constants to config or settings
            var config = new GameConfig
            {
                BoardWidth = 9,
                BoardHeight = 9,
                NumberOfMines = 10
            };

            var game = Game.CreateGame(config);

            var gameButtonsViewModel = new GameButtonsViewModel(game);
            GameButtonsViewModel.DataContext = gameButtonsViewModel;

            var gameBoardViewModel = new GameBoardViewModel(game.Board, game.OpenCell);
            GameBoardViewModel.ItemsSource = gameBoardViewModel.Cells;

            var gameDetailsViewModel = new GameDetailsViewModel(game);
            GameDetailsViewModel.DataContext = gameDetailsViewModel;
        }
    }
}