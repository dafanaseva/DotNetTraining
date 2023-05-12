namespace Task2.Calculator;

public class ExecutionContext
{
    public Stack<float> Stack { get; }
    public Dictionary<string, float> Parameters { get; }

    public ExecutionContext(Stack<float> stack, Dictionary<string, float> parameters)
    {
        Stack = stack;
        Parameters = parameters;
    }
}