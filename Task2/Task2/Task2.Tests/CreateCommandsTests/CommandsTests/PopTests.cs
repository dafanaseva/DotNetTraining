using Moq;
using Task2.CreateCommands;
using Task2.CreateCommands.Commands;

namespace Task2.Tests.CreateCommandsTests.CommandsTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class PopTests
{
    private readonly Pop _systemUnderTest = new();
    private readonly Mock<IExecutionContext> _executionContextSpy = new();

    [Test]
    public void TestExecute_ShouldDeleteAndGetValueFromExecutionContext()
    {
        _systemUnderTest.Execute(_executionContextSpy.Object);

        _executionContextSpy.Verify(t => t.PopValue(true), Times.Once);
        _executionContextSpy.Verify(t => t.PopValue(false), Times.Never);
    }
}