namespace Task2.Read.Exceptions;

internal sealed class ParsingCommandInfoException : Exception
{
    public ParsingCommandInfoException(string? message) : base(message)
    {
    }
}