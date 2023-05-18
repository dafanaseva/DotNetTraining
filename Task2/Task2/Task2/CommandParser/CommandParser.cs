using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Task2.CommandParser;

internal static partial class CommandParser
{
    private const int ParametersStartsFromIndex = 1;
    private const int GroupMatchStartIndex = 1;

    private static readonly Regex CommandNameAndArguments = CommandPatternRegex();

    public static CommandData Parse(string input)
    {
        if (!CommandNameAndArguments.IsMatch(input))
        {
            throw new ParseCommandException($"Wrong command syntax: {input}");
        }

        var matches = GetMatchedGroupValues(input);

        Debug.Assert(!matches.Any(), "No matched groups found");

        var commandName = matches.First();
        var parameters = matches.Skip(ParametersStartsFromIndex).Select(x => (object)x).ToArray();

        return new CommandData(commandName, parameters);
    }

    private static List<string> GetMatchedGroupValues(string input)
    {
        var firstMatch = CommandPatternRegex().Matches(input).First();
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

    [GeneratedRegex("^([A-Z\\*\\/\\-\\#\\+]+)\\s*(\\w+)*\\s*(-?\\d+[\\.\\,]?\\d*)?$")]
    private static partial Regex CommandPatternRegex();
}