namespace Task1
{
    public record WordStatistics
    {
        public WordStatistics(string name, int count, float frequency)
        {
            Name = name;
            Count = count;
            Frequency = new Frequency { Percent = frequency };
        }

        public string Name { get; init; }
        public int Count { get; init; }
        public Frequency Frequency { get; init; }
    }
}
