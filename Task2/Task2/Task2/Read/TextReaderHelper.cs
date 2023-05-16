namespace Task2.Read;

internal static class TextReaderHelper
{
    public static IEnumerable<string> ReadLines(this TextReader reader)
    {
        while (reader.Peek() !=-1)
        {
            var line =  reader.ReadLine();

            if (line == null)
            {
                yield break;
            }

            yield return line;
        }
    }
}