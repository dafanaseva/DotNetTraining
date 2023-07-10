namespace Task3.ConsoleUI.Commands;

internal sealed class UnknownCommandException : Exception
{
    public UnknownCommandException()
    {
    }

    public UnknownCommandException(string? message) : base(message)
    {
    }
}