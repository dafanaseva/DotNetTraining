namespace Task1;

internal sealed record Frequency
{
    private static readonly Func<double, bool> IsValidPercentage =
        percentage => percentage is > MinPercentage and <= MaxPercentage;

    private const int MinPercentage = 0;
    private const int MaxPercentage = 100;
    private const int NumberOfDecimals = 2;
    private const int MinCount = 0;
    public double Percentage { get; }

    public Frequency(int count, int totalCount)
    {
        Percentage = CalculatePercentage(count, totalCount);
    }

    public Frequency(double percentage)
    {
        Percentage = percentage;
        if (!IsValidPercentage(percentage))
        {
            throw new ArgumentException(
                $"Percentage should be in range from {MinPercentage} to {MaxPercentage}",
                nameof(percentage));
        }
    }

    public override string ToString()
    {
        return $"{Percentage} %";
    }

    private static double CalculatePercentage(int count, int totalCount)
    {
        if (count > totalCount)
        {
            throw new ArgumentException($"Count = {count} should be less or equal to {totalCount}", nameof(count));
        }

        VerifyCount(count);
        VerifyCount(totalCount);

        return decimal.ToDouble(Math.Round(decimal.Divide(count, totalCount) * MaxPercentage, NumberOfDecimals));
    }

    private static void VerifyCount(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException($"Count should be more than {MinCount}", nameof(value));
        }
    }
}