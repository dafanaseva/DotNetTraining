using System.Diagnostics;
using Task3.Models.Cells;

namespace Task3.Models.Game;

internal sealed class Game
{

    private readonly InitializeBoardStep _initializeBoardStep;
    private readonly OpenCellsStep _openCellsStep;

    private readonly Stopwatch _timer;

    private readonly List<TimeSpan> _scoreList;

    public delegate void GameStateHandler();
    public event GameStateHandler? NotifyGameEnded;

    public readonly GameBoard Board;

    public GameState GameState { get; private set; }

    private Game(GameBoard gameBoard, InitializeBoardStep initializeBoardStep, OpenCellsStep openCellsStep)
    {
        Board = gameBoard;
        _initializeBoardStep = initializeBoardStep;
        _openCellsStep = openCellsStep;

        _timer = new Stopwatch();
        _timer.Start();

        _scoreList = new List<TimeSpan>();
    }

    public static Game CreateGame(GameConfig gameConfig)
    {
        var board = new GameBoard(gameConfig.BoardHeight, gameConfig.BoardWidth);

        return new Game(
            board,
            new InitializeBoardStep(board, gameConfig.NumberOfMines, Environment.TickCount),
            new OpenCellsStep(board));
    }

    public void OpenCell(Point coordinate)
    {
        var state = TryOpenCells(coordinate);
        GameState = state;

        switch (state)
        {
            case GameState.Continue:
                return;
            case GameState.Fail:
                NotifyGameEnded?.Invoke();
                break;
            case GameState.Win:
                NotifyGameEnded?.Invoke();
                SaveScore();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void NewGame()
    {
        throw new NotImplementedException();
    }

    public void ExitGame()
    {
        throw new NotImplementedException();
    }

    public static string About()
    {
        return "This is a minesweeper game";
    }

    public string HighScore()
    {
        return _scoreList.OrderDescending().FirstOrDefault().ToString();
    }

    private GameState TryOpenCells(Point point)
    {
        if (Board[point.X, point.Y].IsFlagged)
        {
            return GameState.Continue;
        }

        var cell = Board[point.X, point.Y];

        if (cell.IsMined)
        {
            _openCellsStep.OpenAllCells(point);
            return GameState.Fail;
        }

        if (_openCellsStep.ClosedCellsCount == _initializeBoardStep.TotalNumberOfMines)
        {
            return GameState.Win;
        }

        _initializeBoardStep.InitializeCells(point);
        _openCellsStep.OpenNotMinedCells(point);

        return GameState.Continue;
    }

    private void SaveScore()
    {
        _timer.Stop();
        _scoreList.Add(_timer.Elapsed);
    }
}