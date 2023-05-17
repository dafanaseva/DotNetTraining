namespace Task2.CommandParser;

internal sealed class ParseCommandException : Exception
{
    public ParseCommandException(string? message) : base(message)
    {
    }
}