using Task2.Create.Exceptions;

namespace Task2.Create.Commands;

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
                throw new InvalidCommandArgumentException($"Wrong argument type {argument}");
        }
    }
}