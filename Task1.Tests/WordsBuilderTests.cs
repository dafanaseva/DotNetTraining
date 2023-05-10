using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Task1.Tests;

[TestFixture]
public class WordsBuilderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void EmptyTextTest()
    {
        // Arrange
        var wordsBuilder = new WordsBuilder();

        // Act
        var result = wordsBuilder.GetWords();

        // Assert
        Assert.IsFalse(result.Any());
    }

    [Test]
    public void LettersTest()
    {
        // Arrange
        var wordsBuilder = new WordsBuilder();

        // Act
        foreach (var symbol in "a b c")
        {
            wordsBuilder.Append(symbol);
        }

        // Assert
        var result = wordsBuilder.GetWords();

        Assert.AreEqual(
            new List<WordInfo>
            {
                new("a", 1, 33.33),
                new("b", 1, 33.33),
                new("c", 1, 33.33),
            },
            result);
    }

    [Test]
    public void UpperCaseTest()
    {
        // Arrange
        var wordsBuilder = new WordsBuilder();

        // Act
        foreach (var symbol in "cat CAt dog")
        {
            wordsBuilder.Append(symbol);
        }

        // Assert
        var result = wordsBuilder.GetWords();

        Assert.AreEqual(
            new List<WordInfo>
            {
                new("cat", 2, 66.67),
                new("dog", 1, 33.33)
            },
            result);
    }

    [Test]
    public void IncludeNumbersTest()
    {
        // Arrange
        var wordsBuilder = new WordsBuilder();

        // Act
        foreach (var symbol in "111 111 d0g")
        {
            wordsBuilder.Append(symbol);
        }

        // Assert
        var result = wordsBuilder.GetWords();

        Assert.AreEqual(
            new List<WordInfo>
            {
                new("111", 2, 66.67),
                new("d0g", 1, 33.33),
            },
            result);
    }

    [Test]
    public void IncludeOtherSymbolsTest()
    {
        // Arrange
        var wordsBuilder = new WordsBuilder();

        // Act
        foreach (var symbol in "aaa,bbb.ccc aaa!bbb")
        {
            wordsBuilder.Append(symbol);
        }

        // Assert
        var result = wordsBuilder.GetWords();

        Assert.AreEqual(
            new List<WordInfo>
            {
                new("aaa", 2, 40),
                new("bbb", 2, 40),
                new("ccc", 1, 20),
            },
            result);
    }
}