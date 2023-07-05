namespace Task3.Models.GameProcess;

internal sealed class ScoreList
{
    private readonly List<TimeSpan> _scoreList;

    public ScoreList()
    {
        _scoreList = new List<TimeSpan>();
    }

    public void Add(TimeSpan score)
    {
        var index = _scoreList.BinarySearch(score);

        if (index >= 0)
        {
            _scoreList.Insert(index, score);
        }
        else
        {
            _scoreList.Insert(~index, score);
        }
    }

    public TimeSpan GetHighScore()
    {
        return _scoreList.FirstOrDefault();
    }
}