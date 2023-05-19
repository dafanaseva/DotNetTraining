using Task2.Parse;

namespace Task2.Tests.CommandParserTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CommandParserTests
{
    private readonly CommandParser
        _systemUnderTest = new("^([A-Z\\*\\/\\-\\#\\+]+)\\s*(\\w+)*\\s*(-?\\d+[\\.]?\\d*)?$");

    [TestCaseSource(typeof(CommandParserTestsData ), nameof(CommandParserTestsData.ValidCommands))]
    public void TestParse_ValidCommands_ShouldBeAsExpected((string commandText, CommandData expectedCommandData) data)
    {
        var commandData = _systemUnderTest.Parse(data.commandText);

        Assert.Multiple(() =>
        {
            Assert.That(commandData.Name, Is.EqualTo(data.expectedCommandData.Name));
            Assert.That(commandData.Parameters, Is.EqualTo(data.expectedCommandData.Parameters));
        });
    }

    [TestCaseSource(typeof(CommandParserTestsData ), nameof(CommandParserTestsData.InvalidCommands))]
    public void TestParse_InvalidCommand_ShouldThrow(string command)
    {
        Assert.Throws<ParseCommandException>(() => _systemUnderTest.Parse(command));
    }
}