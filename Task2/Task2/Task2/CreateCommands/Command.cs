namespace Task2.CreateCommands;

internal abstract class Command
{
    public abstract void Execute(ExecutionContext executionContext, params object[] arguments);
}