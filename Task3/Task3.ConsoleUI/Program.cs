using Task3.ConsoleUI;
using Task3.ConsoleUI.Commands;
using Task3.Models.GameBoard;
using Task3.Models.GameProcess;

//todo: move constants to a config

const int width = 9;
const int height = 9;
const int numberOfMines = 10;

var board = new Board(new BoardConfig(width, height, numberOfMines), Environment.TickCount);

var game = new Game(board);

var consoleUi = new ConsoleUi(Console.Out, board);
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