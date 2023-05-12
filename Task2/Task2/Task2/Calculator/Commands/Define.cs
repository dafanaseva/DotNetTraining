namespace Task2.Calculator.Commands;

public class Define : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var argumentName = (string)arguments[0];
        var argumentValue = Convert.ToSingle(arguments[1]);

        executionContext.Parameters[argumentName] = argumentValue;
    }
}