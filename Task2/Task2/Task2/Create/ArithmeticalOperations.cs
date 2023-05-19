using Task2.Create.Exceptions;

namespace Task2.Create;

internal static class ArithmeticalOperations
{
    public static readonly Func<float, float, float> Add = (p1, p2) => p1 + p2;
    public static readonly Func<float, float, float> Subtract = (p1, p2) => p1 - p2;
    public static readonly Func<float, float, float> Multiply = (p1, p2) => p1 * p2;

    public static readonly Func<float, float, float> Divide = (p1, p2) =>
    {
        if (p2 == 0)
        {
            throw new InvalidCommandArgumentException("Can not divide on zero");
        }

        return p1 / p2;
    };

    public static readonly Func<float, float> GetSquareRoot = p =>
    {
        if (p < 0)
        {
            throw new InvalidCommandArgumentException("Can not be less than zero");
        }

        return (float)Math.Sqrt(p);
    };
}