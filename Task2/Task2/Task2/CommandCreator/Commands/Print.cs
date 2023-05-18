namespace Task2.CommandCreator.Commands;

internal sealed class Print : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        Console.WriteLine(executionContext.GetValue(shouldDelete: false));
    }
}