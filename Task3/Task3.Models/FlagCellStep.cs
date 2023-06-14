namespace Task3.Models;

internal sealed class FlagCellStep
{
    private readonly GameBoard _gameBoard;

    public FlagCellStep(GameBoard gameBoard)
    {
        _gameBoard = gameBoard;
    }

    public void FlagCell(int x, int y)
    {
        _gameBoard[x, y].SwitchFlag();
    }
}