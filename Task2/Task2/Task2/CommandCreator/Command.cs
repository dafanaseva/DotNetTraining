namespace Task2.CommandCreator;

internal abstract class Command
{
    public abstract void Execute(ExecutionContext executionContext, params object[] arguments);
}