using Task2.Parse;

namespace Task2.Tests.ParseTests;

internal static class CommandParserTestsData
{
    private const string Define = "DEFINE";

    private const string ParameterA = "a";

    private const float IntegerValue = 4;
    private const float FloatValue = 4.5f;
    private const float NegativeFloatValue = -4.5f;

    private const string Print = "PRINT";

    private const string Comment = "COMMENT";
    private const string ParameterComment = "comment";

    public static readonly (string, CommandData)[] ValidCommands =
    {
        new($"{Define} {ParameterA} {IntegerValue}",
            new CommandData(Define, new[] { (object)ParameterA, (object)IntegerValue })),
        new($"{Define} {ParameterA} {FloatValue}",
            new CommandData(Define, new[] { (object)ParameterA, (object)FloatValue })),
        new($"{Define} {ParameterA} {NegativeFloatValue}",
            new CommandData(Define, new[] { (object)ParameterA, (object)NegativeFloatValue })),
        new(Print, new CommandData(Print, Array.Empty<object>())),
        new($"{Comment} {ParameterComment}", new CommandData(Comment, new[] { (object)ParameterComment })),
    };

    public static readonly string?[] InvalidCommands =
    {
        null,
        "a + b",
        string.Empty,
        "12 minus 10",
        $"{Define} {ParameterA} b",
        $"{Define} {ParameterA} b 10",
        "define a 4",
        "PUSH 4,0"
    };
}