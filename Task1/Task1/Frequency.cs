
namespace Task1
{
    public record Frequency
    {
        public double Percent { get; init; }

        public override string ToString()
        {
            return $"{Percent} %";
        }
    }
}
