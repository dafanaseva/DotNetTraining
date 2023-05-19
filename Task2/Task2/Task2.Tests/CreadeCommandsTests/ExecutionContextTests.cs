using Task2.CreateCommands.Exceptions;

namespace Task2.Tests.CreadeCommandsTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class ExecutionContextTests
{
    private const int ParameterValue = 100;
    private const string ParameterName = "a";

    private readonly ExecutionContext _systemUnderTest = new();

    [Test]
    public void TestSaveValue_Any_ShouldNotThrowException()
    {
        _systemUnderTest.SaveValue(ParameterValue);
    }

    [Test]
    public void TestSaveValue_UniqueParameterName_ShouldNotThrowException()
    {
        _systemUnderTest.SaveParameter(ParameterName, ParameterValue);
    }

    [Test]
    public void TestSaveValue_ExistingParameterName_ShouldThrowException()
    {
        _systemUnderTest.SaveParameter(ParameterName, ParameterValue);

        Assert.Throws<InvalidCommandArgumentException>(() =>
            _systemUnderTest.SaveParameter(ParameterName, ParameterValue)
        );
    }

    [Test]
    public void TestGetValue_EmptyStack_ShouldThrowException()
    {
        Assert.Throws<InvalidCommandArgumentException>(() =>
            _systemUnderTest.GetValue()
        );
    }

    [Test]
    public void TestGetValue_AtLeastOneValueOnStack_ShouldNotThrowException()
    {
        _systemUnderTest.SaveValue(ParameterValue);

       var value = _systemUnderTest.GetValue();
       Assert.That(value, Is.EqualTo(ParameterValue));
    }
}