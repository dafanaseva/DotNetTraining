namespace Task2.CreateCommands.Commands;

internal class ArithmeticalCommand : Command
{
    private readonly Func<float, float, float> _operation;

    public ArithmeticalCommand(Func<float, float, float> operation)
    {
        _operation = operation;
    }

    public override void Execute(IExecutionContext executionContext, params object[] arguments)
    {
        Log.Info($"Start operation of {_operation.Method.Name}.");

        var left = executionContext.PopValue();
        var right = executionContext.PopValue();

        executionContext.SaveValue(_operation(left, right));
    }
}