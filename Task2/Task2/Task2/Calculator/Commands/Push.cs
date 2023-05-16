using Task2.Read;

namespace Task2.Calculator.Commands;

internal sealed class Push : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var argument = arguments[0];

        if (argument is string parameterName)
        {
            if (executionContext.Parameters.TryGetValue(parameterName, out var value))
            {
                executionContext.Stack.Push(value);
                return;
            }
        }

        if (argument is float parameterValue)
        {
            executionContext.Stack.Push(parameterValue);
        }
        else
        {
            throw new Exception("Wrong parameter");
        }
    }
}