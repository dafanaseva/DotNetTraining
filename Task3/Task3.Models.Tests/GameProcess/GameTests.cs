using Task3.Models.GameBoard;
using Task3.Models.GameCell;
using Task3.Models.GameProcess;

namespace Task3.Tests.GameProcess;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class GameTests
{
    private static readonly Cell[,] Cells =
    {
        { GameBoard.Cells.MinedCell, new() { NumberOfMinesAround = 1 } },
        { new() { NumberOfMinesAround = 1 }, new() }
    };

    private readonly Game _systemUnderTest = new(Cells, new BoardConfig(2, 2, 1, 1));

    [Test]
    public void ContinueTest()
    {
        _systemUnderTest.OpenCell(new Point(1, 1));

        Assert.That(_systemUnderTest.GameState, Is.EqualTo(GameState.Continue));
    }

    [Test]
    public void FailTest()
    {
        _systemUnderTest.OpenCell(new Point(0, 0));

        Assert.That(_systemUnderTest.GameState, Is.EqualTo(GameState.Fail));
    }

    [Test]
    public void WinTest()
    {
        _systemUnderTest.OpenCell(new Point(1, 0));
        _systemUnderTest.OpenCell(new Point(0, 1));
        _systemUnderTest.OpenCell(new Point(1, 1));

        Assert.That(_systemUnderTest.GameState, Is.EqualTo(GameState.Win));
    }
}