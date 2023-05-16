using System;
using NUnit.Framework;

namespace Task1.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class WordInfoTests
{
    private const string TestValidValue = "aaa";
    private const int TestValidCount = 100;

    private readonly Frequency _frequency = Frequency.CreateInstance(100);

    private static readonly string[] InvalidValues =
    {
        string.Empty,
        ".",
        "a.a",
        " "
    };

    private WordInfo? _systemUnderTest;

    [TestCase(TestValidValue, TestValidCount)]
    public void TestCreateInstance_ValidArgs_ShouldBeOk(string value, int count)
    {
        Assert.DoesNotThrow(() =>
        {
            _systemUnderTest = WordInfo.CreateInstance(value, count, _frequency);
        });

        Assert.IsNotNull(_systemUnderTest);

        Assert.AreEqual(value, _systemUnderTest!.Value);
        Assert.AreEqual(count, _systemUnderTest!.Count);
        Assert.AreEqual(_frequency, _systemUnderTest!.Frequency);
    }

    [TestCase(-1)]
    [TestCase(0)]
    public void TestCreateInstance_InvalidCount_ShouldThrow(int count)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _systemUnderTest = WordInfo.CreateInstance(TestValidValue, count, _frequency);
        });
    }

    [TestCaseSource(nameof(InvalidValues))]
    public void TestCreateInstance_ValuesIsNotSymbolOrLetter_ShouldThrow(string value)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _systemUnderTest = WordInfo.CreateInstance(value, TestValidCount, _frequency);
        });
    }
}