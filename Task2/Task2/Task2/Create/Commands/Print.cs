namespace Task2.Create.Commands;

internal sealed class Print : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        Console.WriteLine(executionContext.GetValue(shouldDelete: false));
    }
}