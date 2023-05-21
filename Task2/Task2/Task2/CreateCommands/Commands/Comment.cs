using Task2.CreateCommands.Exceptions;

namespace Task2.CreateCommands.Commands;

internal sealed class Comment : Command
{
    private const int CommentArgumentIndex = 0;

    public override void Execute(IExecutionContext executionContext, params object[] arguments)
    {
        Log.Info($"Starting operation of {nameof(Comment)}.");

        if (arguments == null || !arguments.Any())
        {
            throw new InvalidCommandArgumentException("Need at least one argument");
        }

        var comment = (string)arguments[CommentArgumentIndex];

        Log.Info($"Writing comment'{comment}'");
        Console.WriteLine(comment);
    }
}