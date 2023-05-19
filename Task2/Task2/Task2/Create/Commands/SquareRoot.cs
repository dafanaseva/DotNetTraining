namespace Task2.Create.Commands;

internal sealed class SquareRoot : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var p = executionContext.GetValue();

        executionContext.SaveValue(ArithmeticalOperations.SquareRoot(p));
    }
}