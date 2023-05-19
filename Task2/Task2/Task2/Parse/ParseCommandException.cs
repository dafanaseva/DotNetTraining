namespace Task2.Parse;

internal sealed class ParseCommandException : UserException
{
    public ParseCommandException(string message) : base($"Can not recognise command: {message}.")
    {
    }
}