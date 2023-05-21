using Microsoft.Extensions.Configuration;
using Task2;
using Task2.Configuration;
using Task2.CreateCommands;
using Task2.Execute;
using Task2.Parse;

const string fileNameArg = "filename";
const string appSettingsFileName = "appsettings.json";

var logger = typeof(Program).GetLogger();

try
{
    CancelKeyPressedObserver.WaitCancelKeyPressed();

    var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(appSettingsFileName, optional: true)
        .AddCommandLine(args)
        .Build();

    var appConfig = config.Get<AppConfig>() ?? throw new ConfigurationNotFoundException(nameof(AppConfig));

    var filename = config[fileNameArg];
    var readFromFile = filename != null;

    Console.WriteLine(readFromFile
        ? $"Reading commands from the file: {filename}."
        : "Reading commands from the console.");

    var pattern = appConfig.CommandPattern ??
                  throw new ConfigurationNotFoundException(nameof(appConfig.CommandPattern));

    var commands = appConfig.CommandNameClassName ??
                   throw new ConfigurationNotFoundException(nameof(appConfig.CommandNameClassName));

    var @namespace = appConfig.Namespace ?? throw new ConfigurationNotFoundException(nameof(appConfig.Namespace));

    var commandExecutor = new CommandExecutor(new CommandParser(pattern), new CommandCreator(commands, @namespace));

    using var streamReader = readFromFile
        ? new StreamReader(filename!)
        : new StreamReader(Console.OpenStandardInput());

    while (!streamReader.EndOfStream)
    {
        commandExecutor.ExecuteCommand(streamReader.ReadLine());
    }
}
catch (ConfigurationNotFoundException e)
{
    logger.Exception(e);
    Console.WriteLine(e.Message);
}
catch (Exception e)
{
    logger.Exception(e);
    Console.WriteLine("An unexpected error occurred. The execution is stopped.");
}
finally
{
    Console.WriteLine("Press enter to close program.");
    Console.ReadLine();
}