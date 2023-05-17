namespace Task2.CommandCreator.Exceptions;

internal sealed class ExecuteCommandException : Exception
{
    public ExecuteCommandException(string? message) : base(message)
    {
    }
}