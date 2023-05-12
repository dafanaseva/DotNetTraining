using Task2.Read;

namespace Task2.Calculator.Commands;

public class Push : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var argument = arguments[0];

        float value;
        if (argument is string)
        {
            if (executionContext.Parameters.TryGetValue(argument.ToString(), out value))
            {

            }
            else throw new Exception();
        }
        else if (argument is float)
        {
            value = Convert.ToSingle(argument);
        }
        else
        {
            throw new Exception();
        }

        executionContext.Stack.Push(value);
    }
}