using Task2.Create.Exceptions;

namespace Task2.Create;

internal static class ArithmeticalOperations
{
    public static readonly Func<float, float, float> Addition = (p1, p2) => p1 + p2;
    public static readonly Func<float, float, float> Subtraction = (p1, p2) => p1 - p2;
    public static readonly Func<float, float, float> Multiplication = (p1, p2) => p1 * p2;

    public static readonly Func<float, float, float> Division = (p1, p2) =>
    {
        if (p2 == 0)
        {
            throw new InvalidCommandArgumentException("Can not divide on zero");
        }

        return p1 / p2;
    };

    public static readonly Func<float, float> SquareRoot = p =>
    {
        if (p < 0)
        {
            throw new InvalidCommandArgumentException($"Can not be less than zero");
        }

        return (float)Math.Sqrt(p);
    };
}