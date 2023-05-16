namespace Task2.Calculator.Commands;

internal sealed class Print : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        Console.WriteLine(executionContext.Stack.Peek());
    }
}