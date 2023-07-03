namespace Task3.Models.Exceptions;

internal sealed class LessThenZeroArgumentException : OutOfBoundsArgumentException
{
    private LessThenZeroArgumentException(int argument) : base($"The value can not be less then zero: {argument}")
    {
    }

    public static void ThrowIfLessThenZero(int argument)
    {
        if (argument < 0)
        {
            throw new LessThenZeroArgumentException(argument);
        }
    }
}