namespace Task2.Create.Exceptions;

internal sealed class UnknownCommandException : Exception
{
    public UnknownCommandException(string message) : base(message)
    {
    }
}