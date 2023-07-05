namespace Task3.Models.Exceptions;

internal class OutOfBoundsArgumentException : Exception
{
    public OutOfBoundsArgumentException(string message) : base(message)
    {
    }

    public static void ThrowIfEqualsToZero(int argument)
    {
        if (argument == 0)
        {
            throw new OutOfBoundsArgumentException("The value can not be less equal to zero");
        }
    }
}