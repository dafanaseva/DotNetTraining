using Task3.ConsoleUI.Commands;

namespace Task3.ConsoleUI.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CommandParserTests
{
    [TestCase("open 1 1", "open", 2)]
    [TestCase("", "", 0)]
    [TestCase("about", "about", 0)]
    [TestCase("new 1 2 3 4", "new", 4)]
    public void TestParse(string text, string expectedName, int paramsCount)
    {
        var actual = CommandParser.ParseCommand(text);

        Assert.Multiple(() =>
        {
            Assert.That(actual.Name, Is.EqualTo(expectedName));
            Assert.That(actual.Parameters.Length, Is.EqualTo(paramsCount));
        });
    }

    [TestCase("1", 1)]
    public void TestParseInt(string text, int expected)
    {
        var actual = CommandParser.ParseInt(text);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("a")]
    [TestCase("1.1")]
    public void TestParseIntThrows(string text)
    {
        Assert.Throws<UnknownCommandException>(() =>
            CommandParser.ParseInt(text));
    }
}