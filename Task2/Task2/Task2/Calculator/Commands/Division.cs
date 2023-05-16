using Task2.Calculator.Exceptions;

namespace Task2.Calculator.Commands;

internal sealed class Division : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var p1 = executionContext.Stack.Pop();
        var p2 = executionContext.Stack.Pop();
        if (p2 == 0)
        {
            throw new InvalidArithmeticalArgumentException("Can not divide on zero");
        }

        executionContext.Stack.Push(p2 / p1);
    }
}