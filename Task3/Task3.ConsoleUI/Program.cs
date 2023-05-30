using Task3.Models;

//todo: move constants to config
const int width = 9;
const int height = 9;
const int numberOfMines = 10;

var gameField = new GameBoard(width, height, numberOfMines);

ShowCell(5, 5);

void ShowCell(int x, int y)
{
    gameField.OpenCell(x, y);

    Print(gameField.Cells);

    Console.ReadLine();
}

void Print(Cell[,] cl)
{
    Console.WriteLine(new string('-', width * 4));
    var rows = cl.GetUpperBound(0) + 1;
    var columns = cl.Length / rows;

    for (var i = 0; i < rows; i++)
    {
        for (var j = 0; j < columns; j++)
        {
            var c = cl[i, j];
            Console.Write($"|{c.GetValue()}| ");
        }

        Console.WriteLine();
    }
}




