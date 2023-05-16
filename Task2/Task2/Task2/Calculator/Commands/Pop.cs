namespace Task2.Calculator.Commands;

internal sealed class Pop : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        executionContext.Stack.Pop();
    }
}