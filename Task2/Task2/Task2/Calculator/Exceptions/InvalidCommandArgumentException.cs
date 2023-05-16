namespace Task2.Calculator.Exceptions;

internal sealed class InvalidCommandArgumentException : Exception
{
    public InvalidCommandArgumentException(string? message) : base(message)
    {
    }
}