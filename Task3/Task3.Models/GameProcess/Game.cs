using System.Collections.Immutable;
using System.Diagnostics;
using Task3.Models.GameBoard;
using Task3.Models.GameCell;

namespace Task3.Models.GameProcess;

internal sealed class Game
{
    private readonly Stopwatch _timer;
    private readonly ScoreList _scoreList;

    private Cell[,] _cells;
    private ImmutableArray<Point> _notMinedPoints;
    private bool _isInitialized;
    private readonly BoardConfig _config;

    public delegate void GameStateHandler();

    public event GameStateHandler? NotifyGameEnded;

    public GameState GameState { get; private set; }
    public bool IsCancelled { get; set; }

    public Game(Cell[,] cells, BoardConfig config)
    {
        _timer = new Stopwatch();
        _timer.Start();

        _scoreList = new ScoreList();
        _cells = cells;
        _config = config;
        _notMinedPoints = ImmutableArray<Point>.Empty;
    }

    public void OpenCell(Point point)
    {
        if (!_isInitialized)
        {
            (_cells, _notMinedPoints) = InitializeCellsHelper.InitCells(_config, point, _cells);

            _isInitialized = true;
        }

        GameState = GetGameState(_cells[point.X, point.Y]);

        OpenCells(point, GameState);

        if (IsWin())
        {
            GameState = GameState.Win;
        }

        HandleGameState(GameState);
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

    public Cell[,] StartNew()
    {
        _isInitialized = false;

        _cells = InitializeCellsHelper.CreateCells(_config.Width, _config.Height);
        return _cells;
    }

    public bool IsWin()
    {
        var isAllOpened = _notMinedPoints.All(x => _cells[x.X, x.Y].IsOpen);

        return isAllOpened;
    }

    private void OpenCells(Point point, GameState state)
    {
        switch (state)
        {
            case GameState.Fail:
                OpenCellsHelper.OpenAllCells(point, _cells);
                break;
            case GameState.Continue:
                OpenCellsHelper.OpenNotMinedCells(point, _cells);
                break;
            case GameState.Win:
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

        return cell.IsMined ? GameState.Fail : GameState.Continue;
    }

    private void HandleGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Continue:
                return;
            case GameState.Fail:
                NotifyGameEnded?.Invoke();
                break;
            case GameState.Win:
                SaveScore();
                NotifyGameEnded?.Invoke();
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
}