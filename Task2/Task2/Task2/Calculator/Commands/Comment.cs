namespace Task2.Calculator.Commands;

public class Comment : Command
{
    public override void Execute(ExecutionContext executionContext, params object[] arguments)
    {
        var comment = (string)arguments[0];

        Console.WriteLine(comment);
    }
}