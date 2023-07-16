using System.Collections.ObjectModel;
using Task3.Models.GameCell;

namespace Task3.UI.ViewModels;

internal sealed class GameBoardViewModel
{
    private int Rows { get; }
    private int Columns { get; }

    public ObservableCollection<CellViewModel> Cells { get; }

    public GameBoardViewModel(Cell[,] cells, CellViewModel.ClickHandler handler)
    {
        Rows = cells.GetLength(0);
        Columns = cells.GetLength(1);

        Cells = new ObservableCollection<CellViewModel>();

        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                var cellViewModel = new CellViewModel(cells[i, j], new Point(i, j));

                cellViewModel.NotifyCellIsClicked += handler;

               Cells.Add(cellViewModel);
            }
        }
    }
}