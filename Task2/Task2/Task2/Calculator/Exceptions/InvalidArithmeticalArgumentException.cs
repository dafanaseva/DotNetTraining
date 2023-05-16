namespace Task2.Calculator.Exceptions;

internal sealed class InvalidArithmeticalArgumentException : Exception
{
    public InvalidArithmeticalArgumentException(string? message) : base(message)
    {
    }
}