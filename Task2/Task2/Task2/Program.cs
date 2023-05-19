using log4net;
using log4net.Config;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Task2.Configuration;
using Task2.Create;
using Task2.Create.Exceptions;
using Task2.Parse;
using Task2.Run;

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
        .AddCommandLine(args)
        .Build();

    var appConfig = config.Get<AppConfig>() ?? throw new ConfigurationNotFoundException(nameof(AppConfig));

    if (!readFromFile)
    {
        Console.WriteLine($"Type '{appConfig.ExitConsoleText}' to exit.");
    }

    using var streamReader = readFromFile
        ? new StreamReader(Environment.GetCommandLineArgs()[fileNameArgumentIndex])
        : new StreamReader(Console.OpenStandardInput());

    var commandParser = new CommandParser(appConfig.CommandPattern ??
                                          throw new ConfigurationNotFoundException(nameof(appConfig.CommandPattern)));

    var commandCreator = new CommandCreator(appConfig.Commands?.ToDictionary() ??
                                            throw new ConfigurationNotFoundException(nameof(appConfig.Commands)));

    var commandRunner = new CommandRunner();

    while (!streamReader.EndOfStream)
    {
        var line = streamReader.ReadLine();

        if (string.IsNullOrEmpty(line))
        {
            continue;
        }

        if (line.Equals(appConfig.ExitConsoleText ??
                        throw new ConfigurationNotFoundException(nameof(appConfig.ExitConsoleText))))
        {
            break;
        }

        try
        {
            commandParser.Parse(line).Deconstruct(out var name, out var parameters);
            var command = commandCreator.CreateCommand(name);
            commandRunner.RunCommand(command, parameters);
        }
        catch (Exception e) when (e is ParseCommandException or UnknownCommandException)
        {
            Console.WriteLine($"Entered command is invalid: {e.Message}. Please correct the command and try again.");
        }
        catch (Exception e) when (e is InvalidCommandArgumentException)
        {
            Console.WriteLine($"Argument is invalid: {e.Message}");
        }
    }
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
    Console.WriteLine("Press any key to exit.");
    Console.ReadLine();
}