namespace Task2.CommandCreator.Commands;

internal class ArithmeticalCommand : Command
{
    private readonly Func<float, float, float> _operation;

    protected ArithmeticalCommand(Func<float, float, float> operation)
    {
        _operation = operation;
    }

    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var p1 = executionContext.GetLastValue();
        var p2 = executionContext.GetLastValue();

        executionContext.SaveValue(_operation(p1, p2));
    }
}