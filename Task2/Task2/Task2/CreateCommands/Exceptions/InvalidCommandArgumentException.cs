namespace Task2.CreateCommands.Exceptions;

internal sealed class InvalidCommandArgumentException : UserException
{
    public InvalidCommandArgumentException(string message) : base($"Argument is invalid: {message}")
    {
    }
}