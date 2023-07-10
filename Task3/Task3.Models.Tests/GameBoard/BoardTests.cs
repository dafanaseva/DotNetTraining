using Task3.Models.GameBoard;

namespace Task3.Tests.GameBoard;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class BoardTests
{
    private const int Seed = 1;

    private Board? _systemUnderTest;

    [Test]
    public void CreateTest()
    {
        // Arrange
        const int width = 9;
        const int height = 9;
        const int numberOfMines = 9;

        var config = new BoardConfig(width, height, numberOfMines, Seed);

        // Act
        _systemUnderTest = new Board(config);

        // Assert
        Assert.That(_systemUnderTest, Is.Not.Null);
    }
}