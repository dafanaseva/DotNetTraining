using Task3.Models;

namespace Task3.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class GameBoardTests
{
    private readonly GameBoard _systemUnderTest = new(10, 10, 4);

    [Test]
    public void TestOpenCell()
    {
        _systemUnderTest.OpenCell(1, 1);
    }
}