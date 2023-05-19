namespace Task2.CreateCommands.Commands;

internal sealed class Define : Command
{
    private const int ParameterNameIndex = 0;
    private const int ParameterValueIndex = 1;

    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var argumentName = (string)arguments[ParameterNameIndex];
        var argumentValue = Convert.ToSingle(arguments[ParameterValueIndex]);

        executionContext.SaveParameter(argumentName, argumentValue);
    }
}