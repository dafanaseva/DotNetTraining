using System.Text.RegularExpressions;

namespace Task2.Read;

public static partial class CommandParser
{
    private static readonly Regex NameAndParameters = MyRegex();

    public static CommandInput Parse(string input)
    {
        if (!NameAndParameters.IsMatch(input))
        {
            throw new ArgumentException(input);
        }

        var matches = GetMatches(input, NameAndParameters);

        return new CommandInput((string)matches[0], matches.Skip(1).ToArray());
    }

    private static List<object> GetMatches(string input, Regex regex)
    {
        var groups = regex.Matches(input).First().Groups;

        var matches = new List<object>();

        foreach (Group group in groups)
        {
            matches.Add(group.Value);
        }

        return matches.Skip(1).ToList();
    }

    [GeneratedRegex("^([A-Z\\*\\/\\-\\#\\+]+)\\s*(\\w+)*\\s*(\\d+[\\.\\,]?\\d*)*")]
    private static partial Regex MyRegex();
}