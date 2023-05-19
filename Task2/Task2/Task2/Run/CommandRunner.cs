using Task2.Create;
using ExecutionContext = Task2.Create.ExecutionContext;

namespace Task2.Run;

internal sealed class CommandRunner
{
    private readonly ExecutionContext _executionContext;

    public CommandRunner()
    {
        _executionContext = new ExecutionContext();
    }

    public void RunCommand(Command command, params object[] parameters)
    {
        command.Execute(_executionContext, parameters);
    }
}