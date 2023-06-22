namespace Task3.Models;

internal sealed class Game
{
    public readonly GameBoard Board;

    private readonly InitializeBoardStep _initializeBoardStep;
    private readonly OpenCellsStep _openCellsStep;

    private Game(GameConfig gameConfig)
    {
        Board = new GameBoard(gameConfig.BoardHeight, gameConfig.BoardWidth);

        _initializeBoardStep = new InitializeBoardStep(Board, gameConfig.NumberOfMines);
        _openCellsStep = new OpenCellsStep(Board);
    }

    public static Game StartNewGame(GameConfig gameConfig)
    {
        return new Game(gameConfig);
    }

    public void OpenCells(Point coordinate)
    {
        _initializeBoardStep.InitializeCells(coordinate.X, coordinate.Y);
        _openCellsStep.OpenCells(coordinate.X, coordinate.Y);
    }
}