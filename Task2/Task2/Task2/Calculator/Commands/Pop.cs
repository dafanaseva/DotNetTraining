namespace Task2.Calculator.Commands;

public class Pop : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        executionContext.Stack.Pop();
    }
}