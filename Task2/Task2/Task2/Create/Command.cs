namespace Task2.Create;

internal abstract class Command
{
    public abstract void Execute(ExecutionContext executionContext, params object[] arguments);
}