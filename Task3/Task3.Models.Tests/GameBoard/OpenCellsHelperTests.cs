using Task3.Models.GameBoard;
using Task3.Models.GameCell;

namespace Task3.Tests.GameBoard;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class OpenCellsHelperTests
{
    [Test]
    public void CreateTest()
    {
        // Arrange
        var cells = new[,]
        {
            { Cells.MinedCell, new Cell { NumberOfMinesAround = 1 } },
            { new Cell(), new Cell() }
        };

        // Act
        OpenCellsHelper.OpenNotMinedCells(new Point(1, 1), cells);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(cells[0, 0].IsOpen, Is.False);
            Assert.That(cells[0, 1].IsOpen, Is.True);
            Assert.That(cells[1, 0].IsOpen, Is.True);
            Assert.That(cells[1, 1].IsOpen, Is.True);
        });
    }
}