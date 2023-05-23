using log4net;
using Task2.CreateCommands.Exceptions;

namespace Task2.CreateCommands;

internal sealed class ExecutionContext : IExecutionContext
{
    private Stack<float> Stack { get; }
    private Dictionary<string, float> Parameters { get; }

    private readonly ILog _log = typeof(ExecutionContext).GetLogger();

    public ExecutionContext()
    {
        Stack = new Stack<float>();
        Parameters = new Dictionary<string, float>();
    }

    public float PeekValue()
    {
        return PopValue(shouldDelete: false);
    }

    public float PopValue()
    {
        return PopValue(shouldDelete: true);
    }


    public void SaveValue(float value)
    {
        _log.Info($"Saving value '{value}' to the stack.");

        Stack.Push(value);
    }

    public void SaveParameter(string parameterName, float parameterValue)
    {
        _log.Info($"Saving parameter '{parameterName}' '{parameterValue}'.");

        if (!Parameters.TryAdd(parameterName, parameterValue))
        {
            throw new InvalidCommandArgumentException($"The parameter '{parameterName}' already exists.");
        }
    }

    public float GetParameterValue(string parameterName)
    {
        _log.Info($"Getting parameter '{parameterName}'.");

        if (!Parameters.TryGetValue(parameterName, out var parameterValue))
        {
            throw new InvalidCommandArgumentException($"Unknown parameter name: {parameterName}.");
        }

        return parameterValue;
    }

    private float PopValue(bool shouldDelete)
    {
        _log.Info($"Getting value from the stack, deleting: {shouldDelete}.");

        try
        {
            var value = shouldDelete ? Stack.Pop() : Stack.Peek();
            _log.Info(shouldDelete ? $"Pop value '{value}'" : $"Peek value '{value}'.");
            return value;
        }
        catch (InvalidOperationException)
        {
            throw new InvalidCommandArgumentException("Need at least one more value.");
        }
    }
}
