using Task2.Calculator.Exceptions;

namespace Task2.Calculator.Commands;

internal sealed class Comment : Command
{
    private const int CommentArgumentIndex = 0;

    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        try
        {
            var comment = (string)arguments[CommentArgumentIndex];

            Console.WriteLine(comment);
        }
        catch (Exception)
        {
            throw new InvalidCommandArgumentException("Wrong argument");
        }
    }
}