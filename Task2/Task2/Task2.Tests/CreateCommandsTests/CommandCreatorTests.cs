using Task2.CreateCommands;
using Task2.CreateCommands.Commands;
using Task2.CreateCommands.Exceptions;

namespace Task2.Tests.CreateCommandsTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CommandCreatorTests
{
    private readonly CommandCreator _systemUnderTest = new(Types, typeof(Addition).Namespace!);

    private const string ExistingCommandName = "+";
    private const string NotFoundTypeCommandName = "SUM";
    private const string NotExistingTypeName = "AVG";

    private const string AdditionType = nameof(Addition);

    private static readonly Dictionary<string, string> Types = new()
    {
        {ExistingCommandName, AdditionType},
        {NotFoundTypeCommandName, string.Empty}
    };

    private Command? _command;

    [Test]
    public void TestCreateCommand_ExistingCommandName_ShouldReturnCommand()
    {
        Assert.DoesNotThrow(() =>
        {
             _command = _systemUnderTest.CreateCommand(ExistingCommandName);
        });

        Assert.That(_command, Is.Not.Null);

        Assert.That(_command, Is.TypeOf(typeof(Addition)));
    }

    [TestCase(NotFoundTypeCommandName)]
    [TestCase(NotExistingTypeName)]
    public void TestCreateCommand_InvalidCommandName_ShouldThrow(string commandName)
    {
        Assert.Throws<UnknownCommandException>(() =>
        {
            _command = _systemUnderTest.CreateCommand(NotFoundTypeCommandName);
        });

        Assert.That(_command, Is.Null);
    }
}