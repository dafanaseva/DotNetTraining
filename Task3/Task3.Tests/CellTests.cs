using Task3.Models;

namespace Task3.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CellTests
{
    private const int NumberOfMines = 10;
    private const int NegativeNumberOfMines = -1;

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
        _systemUnderTest.SetNumberOfMines(0);

        _systemUnderTest.HasMinedNeighbours();

        Assert.That(_systemUnderTest.IsFlagged, Is.False);
    }

    [Test]
    public void TestHasMinedNeighbours()
    {
        _systemUnderTest.SetNumberOfMines(NumberOfMines);

        _systemUnderTest.HasMinedNeighbours();

        Assert.That(_systemUnderTest.HasMinedNeighbours, Is.True);
    }

    [Test]
    public void TestSetNumberOfMines()
    {
        _systemUnderTest.SetNumberOfMines(NumberOfMines);

        Assert.That(_systemUnderTest.NumberOfMines, Is.EqualTo(NumberOfMines));
    }

    [Test]
    public void TestSetNumberOfMinesThrows()
    {
        Assert.Throws<NegativeArgumentException>(() => _systemUnderTest.SetNumberOfMines(NegativeNumberOfMines));
    }
}