using System.Diagnostics;
using Task3.Models.GameBoard;
using Task3.Models.GameCell;

namespace Task3.Models.GameProcess;

internal sealed class Game
{
    private Board _board;
    private readonly Stopwatch _timer;
    private readonly ScoreList _scoreList;
    public delegate void GameStateHandler();
    public event GameStateHandler? NotifyGameEnded;
    public GameState GameState { get; private set; }
    public bool IsCancelled { get; set; }

    public Game(Board board)
    {
        _board = board;
        _timer = new Stopwatch();
        _timer.Start();

        _scoreList = new ScoreList();
    }

    public void OpenCell(Point point)
    {
        GameState = GetGameState(_board[point.X, point.Y]);

        HandleCell(point, GameState);

        HandleState(GameState);
    }

    public static string About()
    {
        const string description = "This is a minesweeper game";
        return description;
    }

    public TimeSpan HighScore()
    {
        return _scoreList.GetHighScore();
    }

    public void StartNew()
    {
        var config = new BoardConfig(_board.Width, _board.Height, _board.NumberOfMines, Environment.TickCount);

        _board = new Board(config);
    }

    private void HandleCell(Point point, GameState state)
    {
        switch (state)
        {
            case GameState.Fail or GameState.Win:
                _board.OpenAllCells(point);
                break;
            case GameState.Continue:
                _board.InitializeCells(point);
                _board.OpenNotMinedCells(point);
                break;
            default:
                Debug.Fail($"Invalid game state {state}");
                break;
        }
    }

    private GameState GetGameState(Cell cell)
    {
        if (cell.IsFlagged)
        {
            return GameState.Continue;
        }

        if (cell.IsMined)
        {
            return GameState.Fail;
        }

        return IsWin() ? GameState.Win : GameState.Continue;
    }

    private void HandleState(GameState state)
    {
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
                throw new ArgumentOutOfRangeException(nameof(state), state, $"Unknown {nameof(state)}: {state}");
        }
    }

    private void SaveScore()
    {
        _timer.Stop();

        _scoreList.Add(_timer.Elapsed);
    }

    private bool IsWin()
    {
        return _board.ClosedCellsCount == _board.NumberOfMines;
    }
}