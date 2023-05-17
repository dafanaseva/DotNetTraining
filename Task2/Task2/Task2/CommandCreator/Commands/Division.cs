using Task2.CommandCreator.Exceptions;

namespace Task2.CommandCreator.Commands;

internal sealed class Division : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var p1 = executionContext.Stack.Pop();
        var p2 = executionContext.Stack.Pop();
        if (p2 == 0)
        {
            throw new ExecuteCommandException("Can not divide on zero");
        }

        executionContext.Stack.Push(p2 / p1);
    }
}