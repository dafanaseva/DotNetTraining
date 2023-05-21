namespace Task1;

internal sealed record WordInfo
{
    private const int MinCount = 0;
    public string Value { get; }
    public int Count { get; }
    public Frequency Frequency { get; }

    public WordInfo(string value, int count, Frequency frequency)
    {
        if (count <= MinCount)
        {
            throw new ArgumentException($"Count = {count} should be more than {MinCount}", nameof(count));
        }

        if (string.IsNullOrEmpty(value) ||
            string.IsNullOrWhiteSpace(value) ||
            value.Any(x => !char.IsLetterOrDigit(x)))
        {
            throw new ArgumentException("Value should contain only numbers or letters", nameof(value));
        }

        Value = value;
        Count = count;
        Frequency = frequency;
    }
}