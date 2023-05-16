using System;
using NUnit.Framework;

namespace Task1.Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
internal sealed class FrequencyTests
{
    private Frequency? _systemUnderTest;

    [TestCase(1)]
    [TestCase(100)]
    public void TestCreateInstance_ValidPercent_ShouldBeOk(int percentage)
    {
        // Act & Assert
        Assert.DoesNotThrow(() =>
        {
            _systemUnderTest = Frequency.CreateInstance(percentage);
        });

        Assert.IsNotNull(_systemUnderTest);

        Assert.AreEqual(percentage, _systemUnderTest!.Percentage);
    }

    [TestCase(101)]
    [TestCase(0)]
    [TestCase(-1)]
    public void TestCreateInstance_InvalidPercent_ShouldThrow(double percentage)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        {
            _systemUnderTest = Frequency.CreateInstance(percentage);
        });
    }

    [TestCase(1, 1, 100)]
    [TestCase(1, 2, 50)]
    [TestCase(1, 3, 33.33)]
    public void TestCreateInstance_ValidCount_ShouldBeOk(int count, int totalCount, double expectedPercentage)
    {
        // Act & Assert
        Assert.DoesNotThrow(() =>
        {
            _systemUnderTest = Frequency.CreateInstance(count, totalCount);
        });

        Assert.IsNotNull(_systemUnderTest);

        Assert.AreEqual(expectedPercentage, _systemUnderTest!.Percentage);
    }

    [TestCase(0, 1)]
    [TestCase(1, 0)]
    [TestCase(2, 1)]
    public void TestCreateInstance_InvalidCount_ShouldThrow(int count, int totalCount)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        {
            _systemUnderTest = Frequency.CreateInstance(count, totalCount);
        });
    }
}