using Task3.Models.Exceptions;
using Task3.Models.GameCell;

namespace Task3.Tests.GameCell;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class PointTests
{
    private const int X = 1;
    private const int Y = 2;

    private Point? _systemUnderTest;

    [Test]
    public void InitTest()
    {
        _systemUnderTest = new Point(X, Y);

        Assert.That(_systemUnderTest, Is.Not.Null);
    }

    [TestCase(0, -1)]
    [TestCase(-1, 0)]
    public void ThrowsTest(int x, int y)
    {
        Assert.Throws<LessThenZeroArgumentException>(() => _systemUnderTest = new Point(x, y));
    }

    [Test]
    public void GetFlatCoordinateTest()
    {
        // Arrange
        const int width = 2;
        const int expectedCoordinate = 4;

        _systemUnderTest = new Point(X, Y);

        // Act
        var coordinate = _systemUnderTest.GetFlatCoordinate(width);

        // Assert
        Assert.That(coordinate, Is.EqualTo(expectedCoordinate));
    }

    [Test]
    public void DeconstructTest()
    {
        // Arrange
        _systemUnderTest = new Point(X, Y);

        // Act
        var (x, y) = _systemUnderTest;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(x, Is.EqualTo(X));
            Assert.That(y, Is.EqualTo(Y));
        });
    }

    [Test]
    public void GetPointTest()
    {
        // Arrange
       const int numberOfElement = 6;
       const int arrayWidth = 4;

        // Act
        var systemUnderTest = Point.GetPoint(numberOfElement, arrayWidth);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(systemUnderTest.X, Is.EqualTo(X));
            Assert.That(systemUnderTest.Y, Is.EqualTo(Y));
        });
    }

    [TestCase(0, -1)]
    [TestCase(-1, 1)]
    public void GetPointThrowsLessThenZeroTest(int numberOfElement, int arrayWidth)
    {
        Assert.Throws<LessThenZeroArgumentException>(() => Point.GetPoint(numberOfElement, arrayWidth));
    }

    [TestCase(1, 0)]
    public void GetPointThrowsOutOfBoundsTest(int numberOfElement, int arrayWidth)
    {
        Assert.Throws<OutOfBoundsArgumentException>(() => Point.GetPoint(numberOfElement, arrayWidth));
    }

    [Test]
    public void AdditionTest()
    {
        // Arrange
        var left = new Point(X, Y);
        var right = new Point(X, Y);

        // Act
        var result = left + right;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.X, Is.EqualTo(X + X));
            Assert.That(result.Y, Is.EqualTo(Y + Y));
        });
    }
}