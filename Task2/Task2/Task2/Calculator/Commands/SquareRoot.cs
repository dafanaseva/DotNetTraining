namespace Task2.Calculator.Commands;

public class SquareRoot : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var p = executionContext.Stack.Pop();

        executionContext.Stack.Push((float)Math.Sqrt(p));
    }
}