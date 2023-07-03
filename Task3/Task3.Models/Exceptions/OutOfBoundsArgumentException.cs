namespace Task3.Models.Exceptions;

internal class OutOfBoundsArgumentException : Exception
{
    public OutOfBoundsArgumentException(string message) : base(message)
    {
    }
}