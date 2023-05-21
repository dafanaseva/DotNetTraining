using Moq;
using Task2.CreateCommands;
using Task2.CreateCommands.Commands;
using Task2.CreateCommands.Exceptions;

namespace Task2.Tests.CreateCommandsTests.CommandsTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class DefineTests
{
    private readonly Define _systemUnderTest = new();
    private readonly Mock<IExecutionContext> _executionContextSpy = new();

    private const float ValidFloatArg = 1;
    private const string ValidParameterName = "a";
    private const string InvalidTypeArg = "b";

    [Test]
    public void TestExecute_ValidParameter_ShouldSaveToExecutionContext()
    {
        _systemUnderTest.Execute(_executionContextSpy.Object, ValidParameterName, ValidFloatArg);

        _executionContextSpy.Verify(t => t.SaveParameter(ValidParameterName, ValidFloatArg), Times.Once);
    }

    [Test]
    public void TestExecute_InValidParameter_ShouldSaveToExecutionContext()
    {
        Assert.Throws<InvalidCommandArgumentException>(() =>
            _systemUnderTest.Execute(_executionContextSpy.Object, ValidParameterName, InvalidTypeArg));
    }

    [Test]
    public void TestExecute_NoArguments_ShouldThrow()
    {
        Assert.Throws<InvalidCommandArgumentException>(() => _systemUnderTest.Execute(_executionContextSpy.Object));
    }
}