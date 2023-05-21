using Moq;
using Task2.CreateCommands;
using Task2.Execute;
using Task2.Parse;

namespace Task2.Tests.ExecuteTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CommandExecutorTests
{
    private readonly CommandExecutor _systemUnderTest = new(
        new Mock<CommandParser>().Object,
        new Mock<CommandCreator>().Object);

    [Test]
    public void TestExecuteCommandsFromStream_NoErrors_ShouldNotThrow()
    {
        _systemUnderTest.ExecuteCommandsFromStream(new Mock<StreamReader>().Object);
    }
}