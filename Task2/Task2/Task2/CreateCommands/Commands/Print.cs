namespace Task2.CreateCommands.Commands;

internal sealed class Print : Command
{
    public override void Execute(IExecutionContext executionContext, params object[] arguments)
    {
        Log.Info($"Starting {nameof(Print)} operation.");

        Console.WriteLine(executionContext.PopValue(shouldDelete: false));
    }
}