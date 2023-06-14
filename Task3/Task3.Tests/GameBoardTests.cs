using Task3.Models;

namespace Task3.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class GameBoardTests
{
    private readonly OpenCellStep _systemUnderTest = new(new GameBoard(10, 10));

    [Test]
    public void TestOpenCell()
    {
        _systemUnderTest.OpenCells(1, 1);
    }
}