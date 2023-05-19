using Task2.CreateCommands;
using ExecutionContext = Task2.CreateCommands.ExecutionContext;

namespace Task2.Execute;

internal sealed class CommandExecutor
{
    private readonly ExecutionContext _executionContext;

    public CommandExecutor()
    {
        _executionContext = new ExecutionContext();
    }

    public void RunCommand(Command command, params object[] parameters)
    {
        command.Execute(_executionContext, parameters);
    }
}