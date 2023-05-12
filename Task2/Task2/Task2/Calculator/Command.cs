namespace Task2.Calculator;

public abstract class Command
{
    public abstract void Execute(ExecutionContext executionContext, params object[] arguments);
}