using Task2.CreateCommands;
using Task2.Parse;

namespace Task2.Run;

internal sealed class Calculator
{
    private readonly CommandCreator _creator;
    private readonly CommandParser _parser;
    private readonly CommandRunner _runner;

    private readonly string _exitCalculatorText;

    public Calculator(CommandParser commandParser, CommandCreator commandCreator, string exitCalculatorText)
    {
        _parser = commandParser;
        _creator = commandCreator;

        _runner = new CommandRunner();

        _exitCalculatorText = exitCalculatorText;
    }

    public void RunCommands(StreamReader streamReader)
    {
        while (!streamReader.EndOfStream)
        {
            var line = streamReader.ReadLine();

            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            if (line.Equals(_exitCalculatorText))
            {
                break;
            }

            try
            {
                _parser.Parse(line).Deconstruct(out var name, out var parameters);

                var command = _creator.CreateCommand(name);

                _runner.RunCommand(command, parameters);
            }
            catch (Exception e) when (e is UserException)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}