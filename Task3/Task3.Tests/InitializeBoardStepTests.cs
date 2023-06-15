using Task3.Models;

namespace Task3.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class InitializeBoardStepTests
{
    private readonly GameBoard _spy = new(1, 1);
    private readonly InitializeBoardStep _systemUnderTest;

    public InitializeBoardStepTests()
    {
        _systemUnderTest = new InitializeBoardStep(_spy, 1);
    }

    [Test]
    public void TestInit()
    {
        _systemUnderTest.TryInitializeCells(0, 0);

        Assert.That(_spy[0, 0].IsMined, Is.False);
    }
}