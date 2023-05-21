using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Task2.Parse;

internal sealed class CommandParser : ICommandParser
{
    private const int ParametersStartFromIndex = 1;
    private const int GroupMatchStartIndex = 1;

    private readonly Regex _commandPattern;

    public CommandParser(string commandPattern)
    {
        _commandPattern = new Regex(commandPattern);
    }

    public CommandData Parse(string input)
    {
        if (!_commandPattern.IsMatch(input))
        {
            throw new ParseCommandException($"Wrong command syntax: {input}");
        }

        var matches = GetMatchedGroupValues(input);

        Debug.Assert(matches.Any(), "No matched groups found");

        var commandName = matches.First();
        var parameters = matches.Skip(ParametersStartFromIndex).Select(ConvertToObject).ToArray();

        return new CommandData(commandName, parameters);
    }

    private static object ConvertToObject(string value)
    {
        if (float.TryParse(value, out var result))
        {
            return result;
        }

        return value;
    }

    public List<string> GetMatchedGroupValues(string input)
    {
        var firstMatch = _commandPattern.Matches(input).First();
        var matchingGroups = firstMatch.Groups;

        var matches = new List<string>();

        for (var i = GroupMatchStartIndex; i < matchingGroups.Count; i++)
        {
            var value = matchingGroups[i].Value;
            if (!string.IsNullOrEmpty(value))
            {
                matches.Add(value);
            }
        }

        return matches.ToList();
    }
}