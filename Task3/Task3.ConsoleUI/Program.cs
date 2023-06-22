using Task3.ConsoleUI;
using Task3.Models;

//todo: move constants to a config
const int width = 9;
const int height = 9;
const int numberOfMines = 10;

var game = Game.StartNewGame(new GameConfig
{
    BoardWidth = width,
    BoardHeight = height,
    NumberOfMines = numberOfMines
});

var consoleUi = new ConsoleUi(Console.Out, game);

while (true)
{
    var command = Console.ReadLine();
    if (command == "exit")
    {
        return;
    }

    game.OpenCells(new Point(1, 1));

    consoleUi.ShowGameBoard();
}