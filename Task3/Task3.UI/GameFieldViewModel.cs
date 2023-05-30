using System.Collections.ObjectModel;
using Task3.Models;

namespace Task3.UI;

internal sealed class GameFieldViewModel
{
    private readonly GameBoard _gameBoard;
    private int Rows { get; }
    private int Columns { get; }

    public ObservableCollection<CellViewModel> Cells { get; }
    public GameFieldViewModel(int width, int height, int count)
    {
        _gameBoard = new GameBoard(width, height, count);

        Rows = height;
        Columns = width;

        Cells = new ObservableCollection<CellViewModel>();
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                var cellViewModel = new CellViewModel(_gameBoard.Cells[i, j], i, j);
                cellViewModel.NotifyCellIsClicked += ClickOnCell;

               Cells.Add(cellViewModel);
            }
        }
    }

    private void ClickOnCell(Point coordinate)
    {
        _gameBoard.OpenCell(coordinate.X, coordinate.Y);

        foreach (var cell in Cells)
        {
            cell.Update();
        }
    }
}