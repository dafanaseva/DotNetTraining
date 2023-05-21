using System.Collections.Generic;
using System.IO;
using Moq;
using NUnit.Framework;

namespace Task1.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class WordsBuilderHelperTests
{
    private readonly Mock<TextReader> _spyTextReader = new();
    private readonly Mock<TextWriter> _spyTextWriter = new();

    [Test]
    public void TestReadWords_TwoLettersInWord_ShouldReadTwice()
    {
        // Arrange
        _spyTextReader.SetupSequence(x => x.Read()).Returns('a').Returns('a');
        _spyTextReader.SetupSequence(x => x.Peek()).Returns('a').Returns('a').Returns(-1);

        // Act
        WordsBuilderHelper.ReadWords(_spyTextReader.Object);

        // Assert
        _spyTextReader.Verify(t => t.Read(), Times.Exactly(2));
    }

    [Test]
    public void TestWriteWords_OneWord_ShouldWriteOnce()
    {
        // Act
        WordsBuilderHelper.WriteWords(new List<WordInfo> { new("aaa", 1, new Frequency(100)) }, _spyTextWriter.Object);

        // Assert
        _spyTextWriter.Verify(t => t.WriteLine(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void TestWriteWords_NoWords_ShouldNeverWrite()
    {
        // Act
        WordsBuilderHelper.WriteWords(new List<WordInfo>(), _spyTextWriter.Object);

        // Assert
        _spyTextWriter.Verify(t => t.WriteLine(It.IsAny<string>()), Times.Never);
    }
}