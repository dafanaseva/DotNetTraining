using Task3.Models.Exceptions;
using Task3.Models.GameBoard;

namespace Task3.Tests.GameBoard;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class BoardConfigTests
{
    private const int Seed = 1;
    private BoardConfig? _systemUnderTest;

    [Test]
    public void CreateTest()
    {
        // Arrange
        var width = new Width(9);
        var height = new Height(5);
        const int numberOfMines = 10;

        // Act
        _systemUnderTest = new BoardConfig(width.Value, height.Value, numberOfMines, Seed);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(_systemUnderTest, Is.Not.Null);
            Assert.That(_systemUnderTest.Width, Is.EqualTo(width));
            Assert.That(_systemUnderTest.Height, Is.EqualTo(height));
            Assert.That(_systemUnderTest.NumberOfMines, Is.EqualTo(numberOfMines));
        });
    }

    [TestCase(-1, 1, 1)]
    [TestCase(1, -1, 1)]
    [TestCase(1, 1, -1)]
    public void ThrowsLessThenZeroTest(int width, int height, int numberOfMines)
    {
        Assert.Throws<LessThenZeroArgumentException>(() =>
        {
            _systemUnderTest = new BoardConfig(width, height, numberOfMines, Seed);
        });
    }

    [TestCase(1, 1, 2)]
    [TestCase(0, 2, 1)]
    [TestCase(2, 0, 1)]
    [TestCase(2, 2, 0)]
    public void ThrowsOutOfBoundsTest(int width, int height, int numberOfMines)
    {
        Assert.Throws<OutOfBoundsArgumentException>(() =>
        {
            _systemUnderTest = new BoardConfig(width, height, numberOfMines, Seed);
        });
    }
}