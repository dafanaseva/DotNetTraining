using Task3.Models;
using Task3.Models.Cells;
using Task3.Models.Game;

namespace Task3.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class InitializeBoardStepTests
{
    private readonly GameBoard _spy = new(1, 1);
    private readonly InitializeBoardStep _systemUnderTest;

    public InitializeBoardStepTests()
    {
        _systemUnderTest = new InitializeBoardStep(_spy, totalNumberOfMines: 1, seed: 3);
    }

    [Test]
    public void TestInit()
    {
        _systemUnderTest.InitializeCells(new Point(0, 0));

        Assert.That(_spy[0, 0].IsMined, Is.False);
    }
}