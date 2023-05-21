using System.Diagnostics.Contracts;
using System.Text;

namespace Task1;

internal sealed class WordsBuilder
{
    private int _totalWordsCount;
    private readonly Dictionary<string, int> _result;

    private readonly StringBuilder _stringBuilder;

    public WordsBuilder()
    {
        _totalWordsCount = 0;
        _result = new Dictionary<string, int>();

        _stringBuilder = new StringBuilder();
    }

    public void Append(char symbol)
    {
        if (char.IsLetterOrDigit(symbol))
        {
            _stringBuilder.Append(symbol);
        }
        else
        {
            if (_stringBuilder.Length <= 0)
            {
                return;
            }

            AddOrUpdateWord(GetInvariantString(_stringBuilder));
        }
    }

    [Pure]
    public IEnumerable<WordInfo> GetWords()
    {
        if (_stringBuilder.Length > 0)
        {
            AddOrUpdateWord(GetInvariantString(_stringBuilder));
        }

        return _result.OrderByDescending(t => t.Value)
            .Select(t => new WordInfo(t.Key, t.Value, new Frequency(t.Value, _totalWordsCount)))
            .ToList();
    }

    private void AddOrUpdateWord(string word)
    {
        _totalWordsCount++;

        if (_result.ContainsKey(word))
        {
            _result[word] += 1;
        }
        else
        {
            _result[word] = 1;
        }
    }

    private static string GetInvariantString(StringBuilder stringBuilder)
    {
        var result = stringBuilder.ToString().ToLowerInvariant();

        stringBuilder.Clear();

        return result;
    }
}