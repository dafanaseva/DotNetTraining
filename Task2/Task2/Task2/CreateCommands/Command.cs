using log4net;

namespace Task2.CreateCommands;

internal abstract class Command
{
    protected static ILog Log => typeof(Command).GetLogger();

    public abstract void Execute(IExecutionContext executionContext, params object[] arguments);
}