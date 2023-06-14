using System.Collections.ObjectModel;
using Task3.Models;

namespace Task3.UI;

internal sealed class GameBoardViewModel
{
    private int Rows { get; }
    private int Columns { get; }

    private readonly GameBoard _gameBoard;

    private readonly InitializeCellsStep _initializeCellsStep;
    private readonly OpenCellStep _openCellStep;
    private readonly FlagCellStep _flagCellStep;

    public ObservableCollection<CellViewModel> Cells { get; }

    public GameBoardViewModel(int width, int height, int totalNumberOfMines)
    {
        Rows = height;
        Columns = width;

        _gameBoard = new GameBoard(height, width);

        _initializeCellsStep = new InitializeCellsStep(_gameBoard, totalNumberOfMines);
        _openCellStep = new OpenCellStep(_gameBoard);
        _flagCellStep = new FlagCellStep(_gameBoard);

        Cells = new ObservableCollection<CellViewModel>();

        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                var cellViewModel = new CellViewModel(_gameBoard[i, j], i, j);

                cellViewModel.NotifyCellIsClicked += ClickOnCell;
                cellViewModel.NotifyCellIsRightClicked += RightClickOnCell;

               Cells.Add(cellViewModel);
            }
        }
    }

    private void ClickOnCell(Point coordinate)
    {
        if (_gameBoard[coordinate.X, coordinate.Y].IsFlagged)
        {
            return;
        }

        _initializeCellsStep.TryInitializeCells(coordinate.X, coordinate.Y);
        _openCellStep.OpenCells(coordinate.X, coordinate.Y);

        UpdateCells();
    }

    private void RightClickOnCell(Point coordinate)
    {
        _flagCellStep.FlagCell(coordinate.X, coordinate.Y);
    }

    private void UpdateCells()
    {
        foreach (var cell in Cells)
        {
            cell.Update();
        }
    }
}