namespace Task2.CommandCreator;

internal sealed class ExecutionContext
{
    public Stack<float> Stack { get; } = new();
    public Dictionary<string, float> Parameters { get; } = new();
}