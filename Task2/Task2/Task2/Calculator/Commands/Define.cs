using Task2.Calculator.Exceptions;

namespace Task2.Calculator.Commands;

internal sealed class Define : Command
{
    private const int ParameterNameIndex = 0;
    private const int ParameterValueIndex = 1;

    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        try
        {
            var argumentName = (string)arguments[ParameterNameIndex];
            var argumentValue = Convert.ToSingle(arguments[ParameterValueIndex]);

            executionContext.Parameters[argumentName] = argumentValue;
        }
        catch (Exception)
        {
            // todo: message to common constants
            throw new InvalidCommandArgumentException("Wrong argument passed");
        }
    }
}