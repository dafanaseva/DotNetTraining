namespace Task2.CommandCreator.Exceptions;

internal sealed class UnknownCommandException : Exception
{
    public UnknownCommandException(string message) : base(message)
    {
    }
}