using System.Collections.Generic;
using System.IO;
using Moq;
using NUnit.Framework;

namespace Task1.Tests;

public class WordsBuilderHelperTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReadWordsTest()
    {
        // Arrange
        var mockReader = new Mock<TextReader>();

        mockReader.SetupSequence(x => x.Read()).Returns('a').Returns('a');
        mockReader.SetupSequence(x => x.Peek()).Returns('a').Returns('a').Returns(-1);

        // Act
        WordsBuilderHelper.ReadWords(mockReader.Object);

        // Assert
        mockReader.Verify(t => t.Read(), Times.Exactly(2));
    }

    [Test]
    public void WriteWordsTest()
    {
        // Arrange
        var mockWriter = new Mock<TextWriter>();

        // Act
        WordsBuilderHelper.WriteWords(new List<WordInfo> { new("aaa", 1, 100) }, mockWriter.Object);

        // Assert
        mockWriter.Verify(t => t.WriteLine(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void WriteNothingTest()
    {
        // Arrange
        var mockWriter = new Mock<TextWriter>();

        // Act
        WordsBuilderHelper.WriteWords(new List<WordInfo>(), mockWriter.Object);

        // Assert
        mockWriter.Verify(t => t.WriteLine(It.IsAny<string>()), Times.Never);
    }
}