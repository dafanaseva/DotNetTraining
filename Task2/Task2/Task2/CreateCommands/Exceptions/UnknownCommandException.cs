namespace Task2.CreateCommands.Exceptions;

internal sealed class UnknownCommandException : UserException
{
    public UnknownCommandException(string message) : base($"Entered command is invalid: {message}")
    {
    }
}