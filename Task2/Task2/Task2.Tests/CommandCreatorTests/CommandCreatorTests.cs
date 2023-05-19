using Task2.Create;
using Task2.Create.Commands;
using Task2.Create.Exceptions;

namespace Task2.Tests.CommandCreatorTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CommandCreatorTests
{
    private const string ExistingCommandName = "+";
    private const string NotFoundTypeCommandName = "SUM";
    private const string NotExistingTypeName = "AVG";

    private static readonly Type AdditionType = typeof(Addition);

    private static readonly Dictionary<string, Type?> Types = new()
    {
        {ExistingCommandName, AdditionType},
        {NotFoundTypeCommandName, null}
    };

    private Command? _command;

    private readonly CommandCreator _sut = new(Types);

    [Test]
    public void TestCreateCommand_ExistingCommandName_ShouldReturnCommand()
    {
        Assert.DoesNotThrow(() =>
        {
             _command = _sut.CreateCommand(ExistingCommandName);
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
            _command = _sut.CreateCommand(NotFoundTypeCommandName);
        });

        Assert.That(_command, Is.Null);
    }
}