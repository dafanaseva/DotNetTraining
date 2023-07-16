using Task3.Models.GameBoard;

namespace Task3.Tests.GameBoard;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class InitializeCellsHelperTests
{
    [Test]
    public void InitTest()
    {
        // Act
        var cells = InitializeCellsHelper.CreateCells(new Width(2), new Height(2));

        // Assert
        Assert.That(cells, Is.Not.Empty);
    }
}