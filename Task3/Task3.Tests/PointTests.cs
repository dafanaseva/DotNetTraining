using Task3.Models;

namespace Task3.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class PointTests
{
    private Point? _systemUnderTest;

    [Test]
    public void TestInit()
    {
        _systemUnderTest = new Point(1,1);

        Assert.That(_systemUnderTest, Is.Not.Null);
    }

    [TestCase(0, -1)]
    [TestCase(-1, 0)]
    public void TestThrows(int x, int y)
    {
        Assert.Throws<NegativeArgumentException>(() => _systemUnderTest = new Point(x, y));
    }
}