using Microsoft.Extensions.Configuration;
using Task3.ConsoleUI;
using Task3.ConsoleUI.Commands;
using Task3.ConsoleUI.Configuration;
using Task3.Models.Exceptions;
using Task3.Models.GameBoard;
using Task3.Models.GameProcess;
using BoardConfig = Task3.Models.GameBoard.BoardConfig;

const string appSettingsFileName = "appsettings.json";

try
{
    var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(appSettingsFileName, optional: true)
        .Build();

    var appConfig = config.Get<AppConfig>() ?? throw new Exception($"Can not parse {nameof(AppConfig)}");

    var boardConfig = new BoardConfig(appConfig.Width, appConfig.Height, appConfig.NumberOfMines, Environment.TickCount);
    var cells = InitializeCellsHelper.CreateCells(boardConfig.Width, boardConfig.Height);

    var game = new Game(cells, boardConfig);
    var consoleUi = new ConsoleUi(Console.Out, cells);


    var commandExecutor = new CommandExecutor(consoleUi, game, new Dictionary<string, Command>
    {
        { "about", new AboutCommand() },
        { "score", new HighScoresCommand() },
        { "exit", new ExitCommand() },
        { "new", new NewGameCommand() },
        { "open", new OpenCellCommand() }
    });

    while (true)
    {
        var command = Console.ReadLine();

        if (command is null || game.IsCancelled)
        {
            return;
        }

        var parsedCommand = CommandParser.ParseCommand(command);

        commandExecutor.ExecuteCommand(parsedCommand);
    }
}
catch (OutOfBoundsArgumentException e)
{
    Console.WriteLine($"Wrong game parameters: {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine($"Unknown error: {e.Message}");
}