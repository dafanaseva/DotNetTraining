namespace Task1;

public static class WordsBuilderHelper
{
    public static IEnumerable<WordInfo> ReadWords(TextReader reader)
    {
        var wordsBuilder = new WordsBuilder();

        while (reader.Peek() != -1)
        {
            wordsBuilder.Append((char)reader.Read());
        }

        return wordsBuilder.GetWords();
    }

    public static void WriteWords(IEnumerable<WordInfo> data, TextWriter writer)
    {
        foreach (var word in data)
        {
            var values = new[]
            {
                word.Value,
                word.Count.ToString(),
                word.Frequency.ToString()
            };

            writer.WriteLine(string.Join(',', values));
        }
    }
}