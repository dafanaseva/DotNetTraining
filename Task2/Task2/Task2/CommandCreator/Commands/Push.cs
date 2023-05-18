using Task2.CommandCreator.Exceptions;

namespace Task2.CommandCreator.Commands;

internal sealed class Push : Command
{
    private const int ArgumentIndex = 0;

    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var argument = arguments[ArgumentIndex];

        switch (argument)
        {
            case string argumentName:
            {
                var value = executionContext.GetParameterValueByName(argumentName);

                executionContext.SaveValue(value);
                return;
            }
            case float argumentValue:
                executionContext.SaveValue(argumentValue);
                break;
            default:
                throw new InvalidCommandArgumentException($"Wrong argument type {argument}");
        }
    }
}