using Task2.CommandCreator.Exceptions;
using Task2.CommandParser;

namespace Task2.Tests.CommandParserTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CommandParserTests
{
    [TestCase("DEFINE a 4")]
    public void TestParse_ValidCommands_ShouldBeAsExpected(string command)
    {
        CommandParser.CommandParser.Parse(command);
    }

    [TestCase("define a 4")]
    [TestCase("sum")]
    [TestCase("?")]
    public void TestParse_UnknownCommand_ShouldThrow(string command)
    {
        Assert.Throws<ParseCommandException>(() => CommandParser.CommandParser.Parse(command));
    }
}