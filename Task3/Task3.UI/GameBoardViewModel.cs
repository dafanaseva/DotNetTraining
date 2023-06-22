using System.Collections.ObjectModel;
using Task3.Models;

namespace Task3.UI;

internal sealed class GameBoardViewModel
{
    private int Rows { get; }
    private int Columns { get; }

    private readonly Game _game;

    public ObservableCollection<CellViewModel> Cells { get; }

    public GameBoardViewModel(int width, int height, int totalNumberOfMines)
    {
        Rows = height;
        Columns = width;

        _game = Game.StartNewGame(new GameConfig
        {
            BoardHeight = width,
            BoardWidth = height,
            NumberOfMines = totalNumberOfMines
        });

        Cells = new ObservableCollection<CellViewModel>();

        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                var cellViewModel = new CellViewModel(_game.Board[i, j], i, j);

                cellViewModel.NotifyCellIsClicked += ClickOnCell;

               Cells.Add(cellViewModel);
            }
        }
    }

    private void ClickOnCell(Point coordinate)
    {
        if (_game.Board[coordinate.X, coordinate.Y].IsFlagged)
        {
            return;
        }

        _game.OpenCells(coordinate);
    }
}