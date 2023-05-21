namespace Task2.CreateCommands.Commands;

internal sealed class Pop : Command
{
    public override void Execute(IExecutionContext executionContext, params object[] arguments)
    {
        executionContext.PopValue();
    }
}