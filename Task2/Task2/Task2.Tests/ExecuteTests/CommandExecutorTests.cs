using Moq;
using Task2.CreateCommands;
using Task2.CreateCommands.Exceptions;
using Task2.Execute;
using Task2.Parse;

namespace Task2.Tests.ExecuteTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CommandExecutorTests
{
    private const string Text = "PEEK";

    private readonly CommandExecutor _systemUnderTest;

    private readonly Mock<ICommandParser> _commandParserSpy = new();
    private readonly Mock<ICommandCreator> _commandCreatorSpy = new();

    public CommandExecutorTests()
    {
        _systemUnderTest = new CommandExecutor(_commandParserSpy.Object, _commandCreatorSpy.Object);
    }

    [SetUp]
    public void Setup()
    {
        _commandParserSpy
            .Setup(x => x.Parse(It.IsAny<string>()))
            .Returns(new CommandData(Text, Array.Empty<object>()));

        _commandCreatorSpy
            .Setup(x => x.CreateCommand(It.IsAny<string>()))
            .Returns(new Mock<Command>().Object);
    }

    [Test]
    public void TestExecuteCommand_ReadText_ShouldCreateCommand()
    {
        _systemUnderTest.ExecuteCommand(Text);

        _commandCreatorSpy.Verify(t => t.CreateCommand(It.IsAny<string>()), Times.Once);
        _commandParserSpy.Verify(t => t.Parse(It.IsAny<string>()), Times.Once);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void TestExecuteCommand_ReadEmptyLine_ShouldNotCreateCommand(string? commandText)
    {
        _systemUnderTest.ExecuteCommand(commandText);

        _commandCreatorSpy.Verify(t => t.CreateCommand(It.IsAny<string>()), Times.Never);
        _commandParserSpy.Verify(t => t.Parse(It.IsAny<string>()), Times.Never);
    }

    [Test]
    public void TestExecuteCommand_CreateCommandFails_ShouldNotThrow()
    {
        _commandCreatorSpy
            .Setup(x => x.CreateCommand(It.IsAny<string>())).Throws(new UnknownCommandException(string.Empty));

        Assert.DoesNotThrow(() => _systemUnderTest.ExecuteCommand(Text));
    }

    [Test]
    public void TestExecuteCommand_ParseCommandFails_ShouldNotThrow()
    {
        _commandParserSpy
            .Setup(x => x.Parse(It.IsAny<string>())).Throws(new UnknownCommandException(string.Empty));

        Assert.DoesNotThrow(() => _systemUnderTest.ExecuteCommand(Text));
    }
}