using System.Collections;
using Task3.Models.GameProcess;

namespace Task3.Tests.GameProcess;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class ScoreListTests
{
    private const int BestScore = 1;

    private readonly ScoreList _systemUnderTest = new();

    [Test]
    public void AddTest()
    {
        _systemUnderTest.Add(TimeSpan.FromSeconds(BestScore));

        Assert.That(_systemUnderTest.GetHighScore(), Is.EqualTo(TimeSpan.FromSeconds(BestScore)));
    }

    [TestCaseSource(typeof(ScoreListSource))]
    public void AddTest(int[] scoreList)
    {
        foreach (var score in scoreList)
        {
            _systemUnderTest.Add(TimeSpan.FromSeconds(score));
        }

        Assert.That(_systemUnderTest.GetHighScore(), Is.EqualTo(TimeSpan.FromSeconds(BestScore)));
    }

    private class ScoreListSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new[] { 12, 3, 4, BestScore };
            yield return new[] { BestScore, 12, 2, 6, 4 };
            yield return new[] { 12, 4, BestScore, 3 };
            yield return new[] { 12, 4, BestScore, 10, 3 };
        }
    }
}