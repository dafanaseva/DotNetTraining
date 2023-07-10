using Moq;
using Task3.ConsoleUI.Commands;
using Task3.Models.GameBoard;
using Task3.Models.GameProcess;

namespace Task3.ConsoleUI.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CommandExecutorTests
{
    private readonly Board _dummyBoard = new(new BoardConfig(2, 2, 1, 1));

    private CommandExecutor? _systemUnderTest;

    [SetUp]
    public void Setup()
    {
        _systemUnderTest = new CommandExecutor(
            new ConsoleUi(Mock.Of<TextWriter>(), _dummyBoard),
            new Game(_dummyBoard),
            new Dictionary<string, Command>
            {
                { "cmd", Mock.Of<Command>() }
            });

        Assert.That(_systemUnderTest, Is.Not.Null);
    }

    [TestCase("cmd", "p")]
    public void ExecuteCommand(string text, string parameter)
    {
        _systemUnderTest!.ExecuteCommand((text, new[] { parameter }));
    }

    [TestCase("read", "p")]
    public void ExecuteCommandThrows(string text, string parameter)
    {
        Assert.Throws<UnknownCommandException>(() => _systemUnderTest!.ExecuteCommand((text, new[] { parameter })));
    }
}