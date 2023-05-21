namespace Task2.CreateCommands.Commands;

internal sealed class Pop : Command
{
    public override void Execute(IExecutionContext executionContext, params object[] arguments)
    {
        Log.Info($"Starting {nameof(Pop)} operation.");

        executionContext.PopValue();
    }
}