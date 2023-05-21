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
                new("a", 1, new Frequency(33.33)),
                new("b", 1, new Frequency(33.33)),
                new("c", 1, new Frequency(33.33))
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
                new("cat", 2, new Frequency(66.67)),
                new("dog", 1, new Frequency(33.33))
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
                new("111", 2, new Frequency(66.67)),
                new("d0g", 1, new Frequency(33.33)),
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
                new("aaa", 2, new Frequency(40)),
                new("bbb", 2, new Frequency(40)),
                new("ccc", 1, new Frequency(20)),
            },
            result);
    }
}