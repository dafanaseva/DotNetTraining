namespace Task2;

internal abstract class UserException : Exception
{
    protected UserException(string? message) : base(message)
    {
    }
}