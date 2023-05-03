using System.Text;
using Task1.Interfaces;

namespace Task1
{
    public class StatisticsService
    {
        private readonly IReader _reader;
        private readonly IWriter<WordStatistics> _writer;

        public StatisticsService(IReader reader, IWriter<WordStatistics> writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public IEnumerable<WordStatistics> GetWordsFrequency()
        {
            var totalCount = 0;
            var results = new Dictionary<string, int>();

            StringBuilder stringBuilder = new();

            while (_reader.HasNext())
            {
                while (_reader.HasNext())
                {
                    var symbol = _reader.ReadChar();

                    if (!char.IsLetterOrDigit(symbol))
                    {
                        break;
                    }

                    stringBuilder.Append(symbol);
                }

                if (stringBuilder.Length > 0)
                {
                    var word = stringBuilder.ToString().ToLowerInvariant();

                    totalCount += 1;

                    if (results.ContainsKey(word))
                    {
                        results[word] += 1;
                    }
                    else
                    {
                        results[word] = 1;
                    }

                    stringBuilder.Clear();
                }
            }

            return results.OrderByDescending(t => t.Value)
                          .Select(t => new WordStatistics(t.Key, t.Value, (float)Math.Round(decimal.Divide(t.Value, totalCount) * 100, 2)))
                          .ToList();
        }

        public void PrintStatistics()
        {
            _writer.WriteAll(GetWordsFrequency());
        }
    }
}