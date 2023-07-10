using System;
using Task3.Models.GameBoard;
using Task3.Models.GameProcess;
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
            var config = new BoardConfig(9, 9, 10, Environment.TickCount);

            var board = new Board(config);

            var game = new Game(board);

            var gameButtonsViewModel = new GameButtonsViewModel(game);
            GameButtonsViewModel.DataContext = gameButtonsViewModel;

            var gameBoardViewModel = new GameBoardViewModel(board, game.OpenCell);
            GameBoardViewModel.ItemsSource = gameBoardViewModel.Cells;

            var gameDetailsViewModel = new GameDetailsViewModel(game);
            GameDetailsViewModel.DataContext = gameDetailsViewModel;
        }
    }
}