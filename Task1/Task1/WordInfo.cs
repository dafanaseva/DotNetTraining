using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Task1;

internal sealed record WordInfo
{
    private const int MinCount = 0;
    public string Value { get; }
    public int Count { get; }
    public Frequency Frequency { get; }

    private WordInfo(string Value, int Count, Frequency Frequency)
    {
        this.Value = Value;
        this.Count = Count;
        this.Frequency = Frequency;
    }

    [Pure]
    public static WordInfo CreateInstance(string value, int count, Frequency frequency)
    {
        if (count <= MinCount)
        {
            throw new ArgumentException($"Count = {count} should be more than {MinCount}", nameof(count));
        }

        if (string.IsNullOrEmpty(value) ||
            string.IsNullOrWhiteSpace(value) ||
            value.Any(x=> !char.IsLetterOrDigit(x)))
        {
            throw new ArgumentException("Value should contain only numbers or letters", nameof(value));
        }

        return new WordInfo(value, count, frequency);
    }
}