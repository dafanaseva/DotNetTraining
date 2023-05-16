using Task2.Calculator.Exceptions;

namespace Task2.Calculator.Commands;

internal sealed class SquareRoot : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var p = executionContext.Stack.Pop();
        if (p < 0)
        {
            throw new InvalidArithmeticalArgumentException($"Can not get square root from negative value: {p}");
        }

        executionContext.Stack.Push((float)Math.Sqrt(p));
    }
}