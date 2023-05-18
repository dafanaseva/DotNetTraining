namespace Task2.CommandCreator.Commands;

internal sealed class SquareRoot : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var p = executionContext.GetLastValue();

        executionContext.SaveValue(ArithmeticalOperation.SquareRoot(p));
    }
}