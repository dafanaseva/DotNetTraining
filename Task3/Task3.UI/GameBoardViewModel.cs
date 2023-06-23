using System.Collections.ObjectModel;
using Task3.Models.Game;

namespace Task3.UI;

internal sealed class GameBoardViewModel
{
    private int Rows { get; }
    private int Columns { get; }

    public ObservableCollection<CellViewModel> Cells { get; }

    public GameBoardViewModel(GameBoard gameBoard, CellViewModel.ClickHandler handler)
    {
        Rows = gameBoard.Height;
        Columns = gameBoard.Width;

        Cells = new ObservableCollection<CellViewModel>();

        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                var cellViewModel = new CellViewModel(gameBoard[i, j], i, j);

                cellViewModel.NotifyCellIsClicked += handler;

               Cells.Add(cellViewModel);
            }
        }
    }
}