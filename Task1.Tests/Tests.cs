using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Task1.Interfaces;

namespace Task1.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AssertPrintingTest()
        {
            // Arrange
            var mockWriter = new Mock<IWriter<WordStatistics>>();

            var statistics = new StatisticsService(new TestReader("a b c"), mockWriter.Object);

            // Act
            statistics.PrintStatistics();

            // Assert
            mockWriter.Verify(x => x.WriteAll(It.IsAny<IEnumerable<WordStatistics>>()), Times.Once);
        }

        [Test]
        public void AssertLettersTest()
        {
            // Arrange
            var statistics = new StatisticsService(new TestReader("a b c"), new Mock<IWriter<WordStatistics>>().Object);

            // Act
            var result = statistics.GetWordsFrequency();

            // Assert
            Assert.AreEqual(
                new List<WordStatistics>
                {
                    new WordStatistics("a", 1, 33.33f),
                    new WordStatistics("b", 1, 33.33f),
                    new WordStatistics("c", 1, 33.33f),
                },
                result);
        }

        [Test]
        public void AssertEmptyTest()
        {
            // Arrange
            var statistics = new StatisticsService(new TestReader(string.Empty), new Mock<IWriter<WordStatistics>>().Object);

            // Act
            var result = statistics.GetWordsFrequency();

            // Assert
            Assert.IsFalse(result.Any());
        }


        [Test]
        public void AssertUpper—aseTest()
        {
            // Arrange
            var statistics = new StatisticsService(new TestReader("cat CAt dog"), new Mock<IWriter<WordStatistics>>().Object);

            // Act
            var result = statistics.GetWordsFrequency();

            // Assert
            Assert.AreEqual(
                new List<WordStatistics>
                {
                    new WordStatistics("cat", 2, 66.67f),
                    new WordStatistics("dog", 1, 33.33f),
                },
                result);
        }

        [Test]
        public void AssertNumbersTest()
        {
            // Arrange
            var statistics = new StatisticsService(new TestReader("111 111 d0g"), new Mock<IWriter<WordStatistics>>().Object);

            // Act
            var result = statistics.GetWordsFrequency();

            // Assert
            Assert.AreEqual(
                new List<WordStatistics>
                {
                    new WordStatistics("111", 2, 66.67f),
                    new WordStatistics("d0g", 1, 33.33f),
                },
                result);
        }

        [Test]
        public void AssertOtherSymbolsTest()
        {
            // Arrange
            var statistics = new StatisticsService(new TestReader("aaa,bbb.ccc aaa!bbb"), new Mock<IWriter<WordStatistics>>().Object);

            // Act
            var result = statistics.GetWordsFrequency();

            // Assert
            Assert.AreEqual(
                new List<WordStatistics>
                {
                    new WordStatistics("aaa", 2, 40),
                    new WordStatistics("bbb", 2, 40),
                    new WordStatistics("ccc", 1, 20),
                },
                result);
        }
    }
}