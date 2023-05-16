namespace Task2.Calculator;

internal abstract class Command
{
    public abstract void Execute(ExecutionContext executionContext, params object[] arguments);
}