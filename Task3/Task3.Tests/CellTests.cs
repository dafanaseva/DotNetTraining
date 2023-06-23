using Task3.Models.Cells;

namespace Task3.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CellTests
{
    private readonly Cell _systemUnderTest = new();

    [Test]
    public void TestOpen()
    {
        _systemUnderTest.Open();

        Assert.That(_systemUnderTest.IsOpen, Is.True);
    }

    [Test]
    public void TestFlag()
    {
        _systemUnderTest.SwitchFlag();

        Assert.That(_systemUnderTest.IsFlagged, Is.True);
    }

    [Test]
    public void TestUnFlag()
    {
        _systemUnderTest.SwitchFlag();
        _systemUnderTest.SwitchFlag();

        Assert.That(_systemUnderTest.IsFlagged, Is.False);
    }

    [Test]
    public void TestHasNoMinedNeighbours()
    {
        _systemUnderTest.IsAnyNeighbourMined();

        Assert.That(_systemUnderTest.IsFlagged, Is.False);
    }
}