namespace Task3.Models;

internal sealed class NegativeArgumentException : Exception
{
    private NegativeArgumentException(string parameterName) : base($"Can not be negative: {parameterName}")
    {
    }

    public static void ThrowIfLessThenNull(int value)
    {
        if (value < 0)
        {
            throw new NegativeArgumentException(nameof(value));
        }
    }
}