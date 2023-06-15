using Task3.Models;

namespace Task3.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class GameBoardTests
{
    private readonly GameBoard _spy = new(1, 1);
    private readonly OpenCellsStep _systemUnderTest;

    public GameBoardTests()
    {
        _systemUnderTest = new OpenCellsStep(_spy);
    }

    [Test]
    public void TestOpenCell()
    {
        _systemUnderTest.OpenCells(0, 0);

        Assert.That(_spy[0, 0].IsOpen, Is.True);
    }
}