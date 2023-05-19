namespace Task2.Parse;

internal sealed class ParseCommandException : Exception
{
    public ParseCommandException(string? message) : base(message)
    {
    }
}