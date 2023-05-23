using Moq;
using Task2.CreateCommands;
using Task2.CreateCommands.Commands;

namespace Task2.Tests.CreateCommandsTests.CommandsTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class SquareRootTests
{
    private readonly SquareRoot _systemUnderTest = new();
    private readonly Mock<IExecutionContext> _executionContext = new();

    [Test]
    public void TestExecute_ValidArguments_ShouldSaveExpectedResult()
    {
        _executionContext.Setup(t => t.PopValue()).Returns(It.IsAny<float>());

        _systemUnderTest.Execute(_executionContext.Object);

        _executionContext.Verify(t => t.PopValue(), Times.Once);
        _executionContext.Verify(t => t.SaveValue(It.IsAny<float>()), Times.Once);
    }
}