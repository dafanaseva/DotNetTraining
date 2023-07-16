using System.Collections.ObjectModel;
using System.Windows.Data;
using Task3.Models.GameCell;

namespace Task3.UI.ViewModels;

internal sealed class GameBoardViewModel
{
    private int Rows { get; }
    private int Columns { get; }

    public ObservableCollection<CellViewModel> Cells { get; }

    public GameBoardViewModel(Cell[,] cells, CellViewModel.ClickHandler clickHandler)
    {
        Rows = cells.GetHeight().Value;
        Columns = cells.GetWidth().Value;
        Cells = new ObservableCollection<CellViewModel>();

        Init(cells, clickHandler);
    }

    private void Init(Cell[,] cells, CellViewModel.ClickHandler clickHandler)
    {
        Cells.Clear();

        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                var cellViewModel = new CellViewModel(cells[i, j], new Point(i, j));

                cellViewModel.NotifyCellIsClicked += clickHandler;

                Cells.Add(cellViewModel);
            }
        }
    }

    public void OnRefresh(Cell[,] cells, CellViewModel.ClickHandler clickHandler)
    {
        Init(cells, clickHandler);
        CollectionViewSource.GetDefaultView(Cells).Refresh();
    }
}