using System.Diagnostics;
using Task3.Models.GameBoard;
using Task3.Models.GameCell;

namespace Task3.Models.GameProcess;

internal sealed class Game
{
    private readonly Board _board;
    private readonly Stopwatch _timer;
    private readonly ScoreList _scoreList;
    public delegate void GameStateHandler();
    public event GameStateHandler? NotifyGameEnded;
    public GameState GameState { get; private set; }

    public Game(Board board)
    {
        _board = board;

        _timer = new Stopwatch();
        _timer.Start();

        _scoreList = new ScoreList();
    }

    public void OpenCell(Point coordinate)
    {
        var state = OpenCells(coordinate);
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
                //todo: should be a method arg
                throw new ArgumentOutOfRangeException(nameof(state), state, $"Unknown {nameof(state)}: {state}");
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

    public TimeSpan HighScore()
    {
        return _scoreList.GetHighScore();
    }

    private GameState OpenCells(Point point)
    {
        if (_board[point.X, point.Y].IsFlagged)
        {
            return GameState.Continue;
        }

        var cell = _board[point.X, point.Y];

        if (cell.IsMined)
        {
            _board.OpenAllCells(point);
            return GameState.Fail;
        }

        if (_board.AreAllOpened())
        {
            return GameState.Win;
        }

        _board.InitializeCells(point);
        _board.OpenNotMinedCells(point);

        return GameState.Continue;
    }

    private void SaveScore()
    {
        _timer.Stop();

        _scoreList.Add(_timer.Elapsed);
    }
}