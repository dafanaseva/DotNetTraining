using Task3.Models.GameBoard;
using Task3.Models.GameCell;

namespace Task3.Tests.GameBoard;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class InitBoardTests
{
    private const int Width = 9;
    private const int Height = 9;
    private const int NumberOfMines = 9;
    private const int Seed = 1;

    private readonly Board _systemUnderTest = new (new BoardConfig(Width, Height, NumberOfMines, Seed));

    [Test]
    public void InitTest()
    {
        // Act
        _systemUnderTest.InitializeCells(new Point(1, 1));

        // Assert
        Assert.That(_systemUnderTest, Is.Not.Null);
    }
}