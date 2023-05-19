using Moq;
using Task2.CreateCommands;
using Task2.Execute;

namespace Task2.Tests.RunTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CommandRunnerTests
{
    private readonly Mock<Command> _command = new();

    private readonly CommandExecutor _systemUnderTest = new();

    [Test]
    public void TestRun_NoErrors_ShouldNotThrow()
    {
        _systemUnderTest.RunCommand(_command.Object);
    }
}