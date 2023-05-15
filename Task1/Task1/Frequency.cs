namespace Task1;

internal sealed record Frequency
{
    private double Percent { get;}

    private const int MaxPercent = 100;
    private const int NumberOfDigitsToRound = 2;

    public override string ToString()
    {
        return $"{Percent} %";
    }

    public Frequency(int count, int totalCount)
    {
        Percent = decimal.ToDouble(Math.Round(decimal.Divide(count, totalCount) * MaxPercent, NumberOfDigitsToRound));
    }

    public Frequency(double percent)
    {
        Percent = percent;
    }
}