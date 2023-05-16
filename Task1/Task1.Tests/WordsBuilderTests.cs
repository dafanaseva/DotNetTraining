using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Task1.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class WordsBuilderTests
{
    private readonly WordsBuilder _systemUnderTest = new ();

    [Test]
    public void TestGetWords_NoText_ShouldReturnEmptyList()
    {
        // Act
        var result = _systemUnderTest.GetWords();

        // Assert
        Assert.IsFalse(result.Any());
    }

    [Test]
    public void TestGetWords_AppendLetters_ShouldReturnForEachLetter()
    {
        // Act
        foreach (var symbol in "a b c")
        {
            _systemUnderTest.Append(symbol);
        }

        // Assert
        var result = _systemUnderTest.GetWords();

        Assert.AreEqual(
            new List<WordInfo>
            {
                WordInfo.CreateInstance("a", 1, Frequency.CreateInstance(33.33)),
                WordInfo.CreateInstance("b", 1, Frequency.CreateInstance(33.33)),
                WordInfo.CreateInstance("c", 1, Frequency.CreateInstance(33.33))
            },
            result);
    }

    [Test]
    public void TestGetWords_AppendWordsWithUpperCaseLetters_ShouldReturnIgnoredUpperCase()
    {
        // Act
        foreach (var symbol in "cat CAt dog")
        {
            _systemUnderTest.Append(symbol);
        }

        // Assert
        var result = _systemUnderTest.GetWords();

        Assert.AreEqual(
            new List<WordInfo>
            {
                WordInfo.CreateInstance("cat", 2, Frequency.CreateInstance(66.67)),
                WordInfo.CreateInstance("dog", 1, Frequency.CreateInstance(33.33))
            },
            result);
    }

    [Test]
    public void TestGetWords_AppendNumbersInWords_ShouldReturnForEachWord()
    {
        // Act
        foreach (var symbol in "111 111 d0g")
        {
            _systemUnderTest.Append(symbol);
        }

        // Assert
        var result = _systemUnderTest.GetWords();

        Assert.AreEqual(
            new List<WordInfo>
            {
                WordInfo.CreateInstance("111", 2, Frequency.CreateInstance(66.67)),
                WordInfo.CreateInstance("d0g", 1, Frequency.CreateInstance(33.33)),
            },
            result);
    }

    [Test]
    public void TestGetWords_AppendOtherSymbols_ShouldIgnoreOtherSymbols()
    {
        // Act
        foreach (var symbol in "aaa,bbb.ccc aaa!bbb")
        {
            _systemUnderTest.Append(symbol);
        }

        // Assert
        var result = _systemUnderTest.GetWords();

        Assert.AreEqual(
            new List<WordInfo>
            {
                WordInfo.CreateInstance("aaa", 2, Frequency.CreateInstance(40)),
                WordInfo.CreateInstance("bbb", 2, Frequency.CreateInstance(40)),
                WordInfo.CreateInstance("ccc", 1, Frequency.CreateInstance(20)),
            },
            result);
    }
}