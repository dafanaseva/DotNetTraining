namespace Task2.Create.Exceptions;

internal sealed class InvalidCommandArgumentException : Exception
{
    public InvalidCommandArgumentException(string? message) : base(message)
    {
    }
}