using Moq;
using Task3.ConsoleUI.Commands;
using Task3.Models.GameBoard;
using Task3.Models.GameCell;
using Task3.Models.GameProcess;

namespace Task3.ConsoleUI.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CommandExecutorTests
{
    private readonly BoardConfig _dummyConfig = new(2, 2, 1, 1);

    private CommandExecutor? _systemUnderTest;

    [SetUp]
    public void Setup()
    {
        _systemUnderTest = new CommandExecutor(
            new ConsoleUi(Mock.Of<TextWriter>(), new Cell[,]{}),
            new Game(new Cell[,]{}, _dummyConfig),
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