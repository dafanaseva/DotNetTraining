using Task3.Models.Exceptions;
using Task3.Models.GameCell;

namespace Task3.Tests.GameCell;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class CellTests
{
    private readonly Cell _systemUnderTest = new();

    [Test]
    public void OpenTest()
    {
        _systemUnderTest.Open();

        Assert.That(_systemUnderTest.IsOpen, Is.True);
    }

    [Test]
    public void FlagTest()
    {
        _systemUnderTest.SwitchFlag();

        Assert.That(_systemUnderTest.IsFlagged, Is.True);
    }

    [Test]
    public void UnFlagTest()
    {
        _systemUnderTest.SwitchFlag();
        _systemUnderTest.SwitchFlag();

        Assert.That(_systemUnderTest.IsFlagged, Is.False);
    }

    [Test]
    public void IsNotMinedTest()
    {
        Assert.That(_systemUnderTest.IsMined, Is.False);
    }

    [Test]
    public void IsMinedTest()
    {
        _systemUnderTest.IsMined = true;

        Assert.That(_systemUnderTest.IsMined, Is.True);
    }

    [Test]
    public void DefaultNumberOfCellsTest()
    {
        Assert.That(_systemUnderTest.NumberOfMinesAround, Is.EqualTo(0));
    }

    [Test]
    public void NumberOfCellsTest()
    {
        const int numberOfMines = 2;

        _systemUnderTest.NumberOfMinesAround = numberOfMines;

        Assert.That(_systemUnderTest.NumberOfMinesAround, Is.EqualTo(numberOfMines));
    }

    [Test]
    public void NumberOfCellsThrowsTest()
    {
        const int numberOfMines = -1;

        Assert.Throws<LessThenZeroArgumentException>(() =>
        {
            _systemUnderTest.NumberOfMinesAround = numberOfMines;
        });
    }

    [Test]
    public void GetStateSafeTest()
    {
        Assert.That(_systemUnderTest.GetState(), Is.EqualTo(CellState.Safe));
    }

    [Test]
    public void GetStateFlaggedTest()
    {
        _systemUnderTest.SwitchFlag();

        Assert.That(_systemUnderTest.GetState(), Is.EqualTo(CellState.Flag));
    }

    [Test]
    public void GetStateMinedTest()
    {
        _systemUnderTest.IsMined = true;

        Assert.That(_systemUnderTest.GetState(), Is.EqualTo(CellState.Mine));
    }

    [Test]
    public void OpenRaiseEventTest()
    {
        RaiseEventTest(cell => cell.Open());
    }

    [Test]
    public void FlagRaiseEventTest()
    {
        RaiseEventTest(cell => cell.SwitchFlag());
    }

    private void RaiseEventTest(Action<Cell> action)
    {
        // Arrange
        const int expectedRaiseCount = 1;

        var raiseCount = 0;

        _systemUnderTest.NotifyCellStateChanged += delegate
        {
            raiseCount++;
        };

        // Act
        action(_systemUnderTest);

        // Assert
        Assert.That(raiseCount, Is.EqualTo(expectedRaiseCount));
    }
}