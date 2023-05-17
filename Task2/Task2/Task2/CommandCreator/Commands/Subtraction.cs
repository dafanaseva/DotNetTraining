namespace Task2.CommandCreator.Commands;

internal sealed class Subtraction : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var p1 = executionContext.Stack.Pop();
        var p2 = executionContext.Stack.Pop();

        executionContext.Stack.Push(p2 - p1);
    }
}