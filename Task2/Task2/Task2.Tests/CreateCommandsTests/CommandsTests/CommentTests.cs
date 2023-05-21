using Moq;
using Task2.CreateCommands;
using Task2.CreateCommands.Commands;
using Task2.CreateCommands.Exceptions;

namespace Task2.Tests.CreateCommandsTests.CommandsTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CommentTests
{
    private readonly Comment _systemUnderTest = new();
    private readonly Mock<IExecutionContext> _executionContextSpy = new();

    [Test]
    public void TestExecute_ShouldNotChangeExecutionContext()
    {
        _systemUnderTest.Execute(_executionContextSpy.Object, "comment");

        _executionContextSpy.VerifyNoOtherCalls();
    }

    [Test]
    public void TestExecute_NoArguments_ShouldThrow()
    {
        Assert.Throws<InvalidCommandArgumentException>(() => _systemUnderTest.Execute(_executionContextSpy.Object));
    }
}