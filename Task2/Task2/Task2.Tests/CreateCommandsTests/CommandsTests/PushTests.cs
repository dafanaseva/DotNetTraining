using Moq;
using Task2.CreateCommands;
using Task2.CreateCommands.Commands;
using Task2.CreateCommands.Exceptions;

namespace Task2.Tests.CreateCommandsTests.CommandsTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class PushTests
{
    private readonly Push _systemUnderTest = new();
    private readonly Mock<IExecutionContext> _executionContextSpy = new();

    private const float ValidFloatArg = 1;
    private const int InvalidTypeArg = 2;
    private const string ValidParameterName = "a";

    [Test]
    public void TestExecute_ValidFloatArg_ShouldSaveToExecutionContext()
    {
        _systemUnderTest.Execute(_executionContextSpy.Object, ValidFloatArg);

        _executionContextSpy.Verify(t => t.SaveValue(ValidFloatArg), Times.Once);
    }

    [Test]
    public void TestExecute_ValidParameter_ShouldSaveToExecutionContext()
    {
        _executionContextSpy.Setup(x => x.GetParameterValue(ValidParameterName)).Returns(ValidFloatArg);

        _systemUnderTest.Execute(_executionContextSpy.Object, ValidParameterName);

        _executionContextSpy.Verify(t => t.GetParameterValue(ValidParameterName), Times.Once);
        _executionContextSpy.Verify(t => t.SaveValue(ValidFloatArg), Times.Once);
    }

    [Test]
    public void TestExecute_UnknownParameter_ShouldThrow()
    {
        Assert.Throws<InvalidCommandArgumentException>(() =>
            _systemUnderTest.Execute(_executionContextSpy.Object, InvalidTypeArg));
    }

    [Test]
    public void TestExecute_NoArguments_ShouldThrow()
    {
        Assert.Throws<InvalidCommandArgumentException>(() => _systemUnderTest.Execute(_executionContextSpy.Object));
    }
}