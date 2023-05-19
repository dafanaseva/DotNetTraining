using Task2.Create.Exceptions;

namespace Task2.Create;

internal sealed class ExecutionContext
{
    private Stack<float> Stack { get; } = new();
    private Dictionary<string, float> Parameters { get; } = new();

    public float GetValue(bool shouldDelete = true)
    {
        try
        {
            return shouldDelete? Stack.Pop(): Stack.Peek();
        }
        catch (InvalidOperationException)
        {
            throw new InvalidCommandArgumentException("Need at least one more value");
        }
    }

    public void SaveValue(float value)
    {
        Stack.Push(value);
    }

    public void SaveParameter(string parameterName, float parameterValue)
    {
        if (!Parameters.TryAdd(parameterName, parameterValue))
        {
            throw new InvalidCommandArgumentException($"The parameter {parameterName} already exists");
        }
    }

    public float GetParameterValue(string parameterName)
    {
        if (!Parameters.TryGetValue(parameterName, out var parameterValue))
        {
            throw new InvalidCommandArgumentException($"Unknown parameter name: {parameterName}");
        }

        return parameterValue;
    }
}