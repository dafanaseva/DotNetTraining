namespace Task2.CommandCreator.Commands;

internal sealed class Multiplication : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var p1 = executionContext.Stack.Pop();
        var p2 = executionContext.Stack.Pop();

        executionContext.Stack.Push(p1 * p2);
    }
}