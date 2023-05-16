using Task2.Calculator;
using Task2.Read;
using ExecutionContext = Task2.Calculator.ExecutionContext;

const string configName = "config.json";
const int fileNameArgumentIndex = 1;

try
{
    var executionContext = new ExecutionContext(new Stack<float>(), new Dictionary<string, float>());

    var readFromFile = Environment.GetCommandLineArgs().Length <= fileNameArgumentIndex;

    var fileName = string.Empty;
    if (readFromFile)
    {
         fileName = Environment.GetCommandLineArgs()[fileNameArgumentIndex];
    }

    var commandCreator = new CommandCreator(configName);

    using var streamReader = readFromFile
        ? new StreamReader(fileName)
        : new StreamReader(Console.OpenStandardInput());

    foreach (var line in streamReader.ReadLines())
    {
        var commandInput = CommandParser.Parse(line);

        var command = commandCreator.CreateCommand(commandInput.Name);
        command.Execute(executionContext, commandInput.Parameters);
    }
}
catch (Exception exception)
{
    Console.WriteLine(exception.ToString());
}
finally
{
    Console.ReadLine();
}