using Task2.CommandCreator.Exceptions;

namespace Task2.Tests.CommandCreatorTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class ExecutionContextTests
{
    private readonly ExecutionContext _systemUnderTest = new();

    [TestCase(1)]
    public void TestSaveValue_Any_ShouldNotThrowException(float value)
    {
        _systemUnderTest.SaveValue(value);
    }

    [TestCase("a", 100)]
    public void TestSaveValue_UniqueParameterName_ShouldNotThrowException(string parameterName, float parameterValue)
    {
        _systemUnderTest.SaveParameter(parameterName, parameterValue);
    }

    [TestCase("a", 100)]
    public void TestSaveValue_ExistingParameterName_ShouldThrowException(string parameterName, float parameterValue)
    {
        _systemUnderTest.SaveParameter(parameterName, parameterValue);

        Assert.Throws<InvalidCommandArgumentException>(() =>
            _systemUnderTest.SaveParameter(parameterName, parameterValue)
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
        _systemUnderTest.SaveValue(1);

       var value = _systemUnderTest.GetValue();
       Assert.AreEqual(1, value);
    }
}