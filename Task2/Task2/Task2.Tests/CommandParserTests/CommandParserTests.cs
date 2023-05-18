using Task2.CommandParser;

namespace Task2.Tests.CommandParserTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CommandParserTests
{
    private const string Define = "DEFINE";

    private const string ParameterA = "a";

    private const string IntegerValue = "4";
    private const string FloatValue = "4.5";
    private const string FloatCommaValue = "4,5";
    private const string NegativeFloatValue = "-4.5";

    private const string Print = "PRINT";

    private const string Comment = "COMMENT";
    private const string ParameterComment = "comment";

    private static readonly (string, CommandData)[] ValidCommands =
    {
        new($"{Define} {ParameterA} {IntegerValue}",
            new CommandData(Define, new[] { (object)ParameterA, (object)IntegerValue })),
        new($"{Define} {ParameterA} {FloatValue}",
            new CommandData(Define, new[] { (object)ParameterA, (object)FloatValue })),
        new($"{Define} {ParameterA} {FloatCommaValue}", new CommandData(Define, new[] { (object)ParameterA, (object)FloatCommaValue })),
        new($"{Define} {ParameterA} {NegativeFloatValue}",
            new CommandData(Define, new[] { (object)ParameterA, (object)NegativeFloatValue })),
        new(Print, new CommandData(Print, Array.Empty<object>())),
        new($"{Comment} {ParameterComment}", new CommandData(Comment, new[] { (object)ParameterComment })),
    };

    private static readonly string[] InvalidCommands =
    {
        "a + b",
        string.Empty,
        "12 minus 10",
        $"{Define} {ParameterA} b",
        $"{Define} {ParameterA} b 10",
        "define a 4"
    };

    [TestCaseSource(nameof(ValidCommands))]
    public void TestParse_ValidCommands_ShouldBeAsExpected((string name, CommandData data) command)
    {
        var commandData = CommandParser.CommandParser.Parse(command.name);

        Assert.Multiple(() =>
        {
            Assert.That(commandData.Name, Is.EqualTo(command.data.Name));
            Assert.That(commandData.Parameters, Is.EqualTo(command.data.Parameters));
        });
    }

    [TestCaseSource(nameof(InvalidCommands))]
    public void TestParse_InvalidCommand_ShouldThrow(string command)
    {
        Assert.Throws<ParseCommandException>(() => CommandParser.CommandParser.Parse(command));
    }
}