namespace Task2.CreateCommands.Commands;

internal sealed class SquareRoot : Command
{
    public override void Execute(IExecutionContext executionContext, params object[] arguments)
    {
        var p = executionContext.PopValue();

        executionContext.SaveValue(ArithmeticalOperations.GetSquareRoot(p));
    }
}