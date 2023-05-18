namespace Task2.CommandCreator.Exceptions;

internal sealed class InvalidCommandArgumentException : Exception
{
    public InvalidCommandArgumentException(string? message) : base(message)
    {
    }
}