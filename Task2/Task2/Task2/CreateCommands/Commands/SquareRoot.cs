namespace Task2.CreateCommands.Commands;

internal sealed class SquareRoot : Command
{
    public override void Execute(IExecutionContext executionContext, params object[] arguments)
    {
        Log.Info($"Starting {nameof(SquareRoot)} operation.");

        var argument = executionContext.PopValue();

        executionContext.SaveValue(ArithmeticalOperations.GetSquareRoot(argument));
    }
}