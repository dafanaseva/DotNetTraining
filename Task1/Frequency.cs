
namespace Task1
{
    public record Frequency
    {
        public float Percent { get; init; }

        public override string ToString()
        {
            return $"{Percent} %";
        }
    }
}
