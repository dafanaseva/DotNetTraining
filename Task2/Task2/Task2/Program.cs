using Task2.Calculator;
using Task2.Read;
using ExecutionContext = Task2.Calculator.ExecutionContext;

try
{
    var executionContext = new ExecutionContext(new Stack<float>(), new Dictionary<string, float>());

    var readFromFile = Environment.GetCommandLineArgs().Length <= 1;

    var fileName = string.Empty;
    if (readFromFile)
    {
         fileName = Environment.GetCommandLineArgs()[1];
    }

    var commandCreator = new CommandCreator("config.json");

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