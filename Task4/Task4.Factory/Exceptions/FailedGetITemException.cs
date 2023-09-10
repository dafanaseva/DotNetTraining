namespace Task4.Factory.Exceptions;

internal sealed class FailedGetITemException : Exception
{
    public FailedGetITemException(string? item) : base($"Can not get {item}")
    {
    }
}