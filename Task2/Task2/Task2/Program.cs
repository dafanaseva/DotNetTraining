using log4net;
using log4net.Config;
using System.Reflection;
using Task2;

var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
var logger = LogManager.GetLogger(typeof(Program));

const string commandsConfigPath = "config.json";
const int fileNameArgumentIndex = 1;
try
{
    logger.Info("The program is started");
    var readFromFile = Environment.GetCommandLineArgs().Length > fileNameArgumentIndex;

    string? fileName = null;

    if (readFromFile)
    {
        fileName = Environment.GetCommandLineArgs()[fileNameArgumentIndex];
    }

    Console.WriteLine(readFromFile
        ? $"Read commands from the file: {fileName}."
        : "Please use console to type a command.");

    using var streamReader = readFromFile
        ? new StreamReader(fileName!)
        : new StreamReader(Console.OpenStandardInput());

    var commandRunner = new CommandRunner(commandsConfigPath);

    foreach (var line in streamReader.ReadLines())
    {
        commandRunner.RunCommand(line);
    }
}
catch (Exception e) when(e is FileNotFoundException or
                             DirectoryNotFoundException or
                             IOException)
{
    Console.WriteLine("File can not be found.");
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