namespace Task2.CreateCommands.Commands;

internal sealed class Pop : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        executionContext.GetValue(shouldDelete: false);
    }
}