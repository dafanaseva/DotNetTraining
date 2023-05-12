namespace Task2.Calculator.Commands;

public class Print : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        Console.WriteLine(executionContext.Stack.Peek());
    }
}