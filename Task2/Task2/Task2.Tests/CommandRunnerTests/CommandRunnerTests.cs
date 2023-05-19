using Moq;
using Task2.Create;
using Task2.Run;

namespace Task2.Tests.CommandRunnerTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CommandRunnerTests
{
    private readonly Mock<Command> _command = new();

    private readonly CommandRunner _systemUnderTest = new();

    [Test]
    public void TestRun_NoErrors_ShouldNotThrow()
    {
        _systemUnderTest.RunCommand(_command.Object);
    }
}