using System.Text.RegularExpressions;
using Task2.Read.Exceptions;

namespace Task2.Read;

internal static class CommandParser
{
    private const int CaptureGroupStartIndex = 1;

    private static readonly Regex CommandNameAndArguments =
        new("^([A-Z\\*\\/\\-\\#\\+]+)\\s*(\\w+)*\\s*(\\d+[\\.\\,]?\\d*)*");

    public static CommandInfo Parse(string input)
    {
        if (!CommandNameAndArguments.IsMatch(input))
        {
            throw new ParsingCommandInfoException($"Wrong command syntax: {input}");
        }

        var matches = GetMatches(input, CommandNameAndArguments);

        var commandName = matches.First();

        return new CommandInfo(commandName, matches.Skip(CaptureGroupStartIndex).Select(x => (object)x).ToArray());
    }

    private static List<string> GetMatches(string input, Regex regex)
    {
        var groups = regex.Matches(input).First().Groups;

        var matches = new List<string>();

        foreach (Group group in groups)
        {
            matches.Add(group.Value);
        }

        return matches.Skip(CaptureGroupStartIndex).ToList();
    }
}