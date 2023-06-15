using Task3.Models;

namespace Task3.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class FlagCellStepTests
{
    private readonly GameBoard _spy = new(1, 1);
    private readonly FlagCellStep _systemUnderTest;

    public FlagCellStepTests()
    {
        _systemUnderTest = new FlagCellStep(_spy);
    }

    [Test]
    public void TestFlag()
    {
        _systemUnderTest.FlagCell(0, 0);

        Assert.That(_spy[0, 0].IsFlagged, Is.True);
    }
}