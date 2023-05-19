using Task2.CreateCommands.Exceptions;

namespace Task2.CreateCommands.Commands;

internal sealed class Push : Command
{
    private const int ArgumentIndex = 0;

    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var argument = arguments[ArgumentIndex];

        switch (argument)
        {
            case float argumentValue:
                executionContext.SaveValue(argumentValue);
                break;
            case string argumentName:
            {
                var value = executionContext.GetParameterValue(argumentName);

                executionContext.SaveValue(value);
                return;
            }
            default:
                throw new InvalidCommandArgumentException("Argument should be literal or numeric value");
        }
    }
}