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
    private const int EndOfStream = -1;

    private readonly CommandExecutor _systemUnderTest;

    private static readonly Mock<TextReader> TextReaderSpy = new ();

    private readonly Mock<ICommandParser> _commandCommandParser = new();
    private readonly Mock<ICommandCreator> _commandCreatorSpy = new();

    public CommandExecutorTests()
    {
        _systemUnderTest = new CommandExecutor(_commandCommandParser.Object, _commandCreatorSpy.Object);
    }

    [SetUp]
    public void Setup()
    {
        TextReaderSpy.SetupSequence(x => x.Peek()).Returns(char.MinValue).Returns(EndOfStream);

        _commandCommandParser.Setup(x => x.Parse(It.IsAny<string>()))
            .Returns(new CommandData(Text, Array.Empty<object>()));
    }

    [Test]
    public void TestExecuteCommands_ReadText_ShouldCreateCommand()
    {
        TextReaderSpy.Setup(x => x.ReadLine()).Returns(Text);

        _commandCreatorSpy.Setup(x => x.CreateCommand(It.IsAny<string>())).Returns(new Mock<Command>().Object);

        _systemUnderTest.ExecuteCommands(TextReaderSpy.Object);

        _commandCreatorSpy.Verify(t => t.CreateCommand(It.IsAny<string>()), Times.Once);
        _commandCommandParser.Verify(t => t.Parse(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void TestExecuteCommands_ReadEmptyLine_ShouldNotCreateCommand()
    {
        TextReaderSpy.Setup(x => x.ReadLine()).Returns(string.Empty);

        _systemUnderTest.ExecuteCommands(TextReaderSpy.Object);

        _commandCreatorSpy.Verify(t => t.CreateCommand(It.IsAny<string>()), Times.Never);
        _commandCommandParser.Verify(t => t.Parse(It.IsAny<string>()), Times.Never);
    }

    [Test]
    public void TestExecuteCommands_CreateCommandFails_ShouldNotThrow()
    {
        TextReaderSpy.Setup(x => x.ReadLine()).Returns(Text);

        _commandCreatorSpy.Setup(x => x.CreateCommand(
            It.IsAny<string>())).Throws(new UnknownCommandException(string.Empty));

        Assert.DoesNotThrow(() => _systemUnderTest.ExecuteCommands(TextReaderSpy.Object));
    }

    [Test]
    public void TestExecuteCommands_ParseCommandFails_ShouldNotThrow()
    {
        TextReaderSpy.Setup(x => x.ReadLine()).Returns(Text);

        _commandCommandParser.Setup(x => x.Parse(
            It.IsAny<string>())).Throws(new UnknownCommandException(string.Empty));

        Assert.DoesNotThrow(() => _systemUnderTest.ExecuteCommands(TextReaderSpy.Object));
    }
}