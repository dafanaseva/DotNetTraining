using log4net;
using log4net.Config;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Task2.Configuration;
using Task2.CreateCommands;
using Task2.Execute;
using Task2.Parse;

var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
var logger = LogManager.GetLogger(typeof(Program));

const int fileNameArgumentIndex = 1;

try
{
    var readFromFile = Environment.GetCommandLineArgs().Length > fileNameArgumentIndex;

    Console.WriteLine(readFromFile
        ? "Read commands from the file."
        : "Please use console to type a command.");

    var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true)
        .Build();

    var appConfig = config.Get<AppConfig>() ?? throw new ConfigurationNotFoundException(nameof(AppConfig));

    if (!readFromFile)
    {
        Console.WriteLine($"Type '{appConfig.ExitConsoleText}' to exit.");
    }

    var parser = new CommandParser(appConfig.CommandPattern ??
                                   throw new ConfigurationNotFoundException(nameof(appConfig.CommandPattern)));

    var creator = new CommandCreator(appConfig.Commands?.ToDictionary() ??
                                     throw new ConfigurationNotFoundException(nameof(appConfig.Commands)));

    var exitCalculatorText = appConfig.ExitConsoleText ??
                             throw new ConfigurationNotFoundException(nameof(appConfig.ExitConsoleText));

    var calculator = new Calculator(parser, creator, exitCalculatorText);

    using var streamReader = readFromFile
        ? new StreamReader(Environment.GetCommandLineArgs()[fileNameArgumentIndex])
        : new StreamReader(Console.OpenStandardInput());

    calculator.RunCommands(streamReader);
}
catch (ConfigurationNotFoundException e)
{
    Console.WriteLine(e.Message);
}
catch (Exception e)
{
    logger.Error(e);
    Console.WriteLine("An unexpected error occurred. The execution is stopped.");
}
finally
{
    Console.WriteLine("Press enter to close program.");
    Console.ReadLine();
}