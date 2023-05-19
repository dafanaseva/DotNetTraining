namespace Task2.Create.Commands;

internal sealed class Comment : Command
{
    private const int CommentArgumentIndex = 0;

    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var comment = (string)arguments[CommentArgumentIndex];

        Console.WriteLine(comment);
    }
}