using System.Diagnostics;
using System.Text.RegularExpressions;
using log4net;

namespace Task2.Parse;

internal sealed class CommandParser : ICommandParser
{
    private const int ParametersStartFromIndex = 1;
    private const int GroupMatchStartIndex = 1;

    private readonly Regex _commandPattern;

    private readonly ILog _log;

    public CommandParser(string commandPattern)
    {
        _commandPattern = new Regex(commandPattern);

        _log = typeof(CommandParser).GetLogger();
    }

    public CommandData Parse(string input)
    {
        _log.Info($"Start parsing entered text '{input}'.");

        if (string.IsNullOrEmpty(input))
        {
            throw new ParseCommandException("Command can not be empty.");
        }

        if (!_commandPattern.IsMatch(input))
        {
            throw new ParseCommandException($"Wrong command syntax: '{input}'.");
        }

        var matches = GetMatchedGroupValues(input);

        Debug.Assert(matches.Any(), "No matched groups found.");

        var commandName = matches.First();
        var parameters = matches.Skip(ParametersStartFromIndex).Select(ConvertToObject).ToArray();

        return new CommandData(commandName, parameters);
    }

    private List<string> GetMatchedGroupValues(string input)
    {
        Debug.Assert(input != null, "input != null");

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

    private static object ConvertToObject(string value)
    {
        if (float.TryParse(value, out var result))
        {
            return result;
        }

        return value;
    }
}
