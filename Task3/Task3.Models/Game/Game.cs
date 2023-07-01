using System.Diagnostics;
using Task3.Models.Cells;
using Task3.Models.Game.GameBoard;

namespace Task3.Models.Game;

internal sealed class Game
{
    private readonly Stopwatch _timer;

    private readonly List<TimeSpan> _scoreList;

    public delegate void GameStateHandler();
    public event GameStateHandler? NotifyGameEnded;

    public readonly Board Board;

    public GameState GameState { get; private set; }

    private Game(Board board)
    {
        Board = board;

        _timer = new Stopwatch();
        _timer.Start();

        _scoreList = new List<TimeSpan>();
    }

    public static Game CreateGame(GameConfig gameConfig)
    {
        var board = new Board(
            gameConfig.BoardHeight,
            gameConfig.BoardWidth,
            gameConfig.NumberOfMines,
            Environment.TickCount);

        return new Game(board);
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
        return _scoreList.FirstOrDefault().ToString();
    }

    private GameState OpenCells(Point point)
    {
        if (Board[point.X, point.Y].IsFlagged)
        {
            return GameState.Continue;
        }

        var cell = Board[point.X, point.Y];

        if (cell.IsMined)
        {
            Board.OpenAllCells(point);
            return GameState.Fail;
        }

        if (Board.AreAllOpened())
        {
            return GameState.Win;
        }

        Board.InitializeCells(point);
        Board.OpenNotMinedCells(point);

        return GameState.Continue;
    }

    private void SaveScore()
    {
        _timer.Stop();
        //todo: store as sorted list
        _scoreList.Add(_timer.Elapsed);
    }
}