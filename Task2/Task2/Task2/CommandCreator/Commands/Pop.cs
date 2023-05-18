namespace Task2.CommandCreator.Commands;

internal sealed class Pop : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        executionContext.GetLastValue(shouldDelete: false);
    }
}