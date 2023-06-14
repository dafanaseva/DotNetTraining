using Task3.Models;

//todo: move constants to config
const int width = 9;
const int height = 9;
const int numberOfMines = 10;

var board = new GameBoard(height, width);
var game = new OpenCellStep(board);

ShowCell(5, 5);

void ShowCell(int x, int y)
{
    game.OpenCells(x, y);

    Print(board);

    Console.ReadLine();
}

void Print(GameBoard gameBoard)
{
    var rows = gameBoard.Height;
    var columns = gameBoard.Width;

    for (var i = 0; i < rows; i++)
    {
        for (var j = 0; j < columns; j++)
        {
            var cell = gameBoard[i, j];
            Console.Write($"|{cell.GetValue()}| ");
        }

        Console.WriteLine();
    }
}




