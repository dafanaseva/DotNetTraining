using Task3.Models.GameBoard;
using Task3.Models.GameCell;
using Task3.Models.GameProcess;

namespace Task3.Tests.GameProcess;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class GameTests
{
    private readonly Game _systemUnderTest = new(new Board(new BoardConfig(9, 9, 9, 1)));

    [Test]
    public void OpenCellTest()
    {
        _systemUnderTest.OpenCell(new Point(1, 1));

        Assert.That(_systemUnderTest.GameState, Is.EqualTo(GameState.Continue));
    }
}