using Task2.CreateCommands;

namespace Task2.Tests.CreadeCommandsTests.CommandsTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal abstract class CommandBaseTest<T> where T: Command, new()
{
    private readonly T _systemUnderTest = new();
    private readonly ExecutionContext _executionContext = new();

    protected void TestExecute_ValidArguments_ShouldSaveExpectedResult(float expectedResult)
    {
        _systemUnderTest.Execute(_executionContext);

        Assert.That(_executionContext.GetValue(), Is.EqualTo(expectedResult));
    }
}