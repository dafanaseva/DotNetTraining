using Task3.ConsoleUI;
using Task3.ConsoleUI.Commands;
using Task3.Models.Game;

//todo: move constants to a config

const int width = 9;
const int height = 9;
const int numberOfMines = 10;

var game = Game.CreateGame(new GameConfig
{
    BoardWidth = width,
    BoardHeight = height,
    NumberOfMines = numberOfMines
});

var consoleUi = new ConsoleUi(Console.Out, game);
var commandExecutor = new CommandExecutor(consoleUi, game);

// todo: register commands

while (true)
{
    var command = Console.ReadLine();

    if (command is "exit" or null)
    {
        return;
    }

    // todo:
    commandExecutor.ExecuteCommand(command);
}