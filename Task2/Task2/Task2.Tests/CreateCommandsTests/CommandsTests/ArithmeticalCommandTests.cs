using Moq;
using Task2.CreateCommands;
using Task2.CreateCommands.Commands;
using Task2.CreateCommands.Exceptions;

namespace Task2.Tests.CreateCommandsTests.CommandsTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class ArithmeticalCommand
{
    private readonly CreateCommands.Commands.ArithmeticalCommand _systemUnderTest = new Addition();
    private readonly Mock<IExecutionContext> _executionContext = new();

    [Test]
    public void TestExecute_ValidArguments_ShouldSaveExpectedResult()
    {
        _executionContext.SetupSequence(t => t.PopValue(It.IsAny<bool>())).Returns(1).Returns(2);

        _systemUnderTest.Execute(_executionContext.Object);

        _executionContext.Verify(t => t.PopValue(It.IsAny<bool>()), Times.Exactly(2));
        _executionContext.Verify(t => t.SaveValue(It.IsAny<float>()), Times.Once);
    }

    [Test]
    public void TestExecute_InvalidArgumentException_ShouldNotSave()
    {
        _executionContext.Setup(t => t.PopValue(It.IsAny<bool>()))
            .Throws(new InvalidCommandArgumentException(string.Empty));

        Assert.Throws<InvalidCommandArgumentException>(
            () => _systemUnderTest.Execute(_executionContext.Object));

        _executionContext.Verify(t => t.SaveValue(It.IsAny<float>()), Times.Never);
    }
}