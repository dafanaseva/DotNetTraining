using Task3.Models;

//todo: move constants to config
const int width = 9;
const int height = 9;
const int numberOfMines = 10;

var board = new GameBoard(width, height, numberOfMines);

ShowCell(5, 5);

void ShowCell(int x, int y)
{
    board.OpenCell(x, y);

    Print(board.Cells);

    Console.ReadLine();
}

void Print(Cell[,] gameBoard)
{
    var rows = gameBoard.GetUpperBound(0) + 1;
    var columns = gameBoard.Length / rows;

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




