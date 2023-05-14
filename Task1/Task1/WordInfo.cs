namespace Task1
{
    public record WordInfo
    {
        public WordInfo(string value, int count, double frequency)
        {
            Value = value;
            Count = count;
            Frequency = new Frequency { Percent = frequency };
        }

        public string Value { get; }
        public int Count { get; }
        public Frequency Frequency { get; }
    }
}
