using Moq;
using Task2.CreateCommands;
using Task2.CreateCommands.Commands;
using Task2.CreateCommands.Exceptions;

namespace Task2.Tests.CreateCommandsTests.CommandsTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class ArithmeticalCommandTests
{
    private readonly ArithmeticalCommand _systemUnderTest = new((a, b) => a + b);

    private readonly Mock<IExecutionContext> _executionContextSpy = new();

    [Test]
    public void TestExecute_ValidArguments_ShouldSaveExpectedResult()
    {
        _executionContextSpy.SetupSequence(t => t.PopValue()).Returns(1).Returns(2);

        _systemUnderTest.Execute(_executionContextSpy.Object);

        _executionContextSpy.Verify(t => t.PopValue(), Times.Exactly(2));
        _executionContextSpy.Verify(t => t.SaveValue(It.IsAny<float>()), Times.Once);
    }

    [Test]
    public void TestExecute_InvalidArgumentException_ShouldNotSave()
    {
        _executionContextSpy.Setup(t => t.PopValue())
            .Throws(new InvalidCommandArgumentException(string.Empty));

        Assert.Throws<InvalidCommandArgumentException>(
            () => _systemUnderTest.Execute(_executionContextSpy.Object));

        _executionContextSpy.Verify(t => t.SaveValue(It.IsAny<float>()), Times.Never);
    }
}