namespace Task2.Calculator.Commands;

public class Addition : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var p1 = executionContext.Stack.Pop();
        var p2 = executionContext.Stack.Pop();

        executionContext.Stack.Push(p1 + p2);
    }
}