using System.Diagnostics;

namespace Task3.ConsoleUI.Commands;

internal static class CommandParser
{
    public static int ParseInt(string text)
    {
        if (int.TryParse(text, out var value))
        {
            return value;
        }

        throw new UnknownCommandException();
    }

    public static (string Name, string[] Parameters) ParseCommand(string text)
    {
        var command = text.Split();

        return (command[0], command.Skip(1).ToArray());
    }
}