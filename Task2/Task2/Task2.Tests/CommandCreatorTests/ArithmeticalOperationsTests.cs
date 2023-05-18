using Task2.CommandCreator;
using Task2.CommandCreator.Exceptions;

namespace Task2.Tests.CommandCreatorTests;

[TestFixture]
internal sealed class ArithmeticalOperationsTests
{
    [TestCase(1, 2, 3)]
    [TestCase(2, 1, 3)]
    public void TestAddition_ValidArgs_ShouldBeAsExpected(float p1, float p2, float expectedResult)
    {
        Assert.That(ArithmeticalOperations.Addition(p1, p2), Is.EqualTo(expectedResult));
    }

    [TestCase(1, 2, 2)]
    [TestCase(2, 1, 2)]
    [TestCase(0, 1, 0)]
    public void TestMultiplication_ValidArgs_ShouldBeAsExpected(float p1, float p2, float expectedResult)
    {
        Assert.That(ArithmeticalOperations.Multiplication(p1, p2), Is.EqualTo(expectedResult));
    }

    [TestCase(2, 2, 0)]
    [TestCase(0, 1, -1)]
    [TestCase(-1, -1, 0)]
    public void TestSubtraction_ValidArgs_ShouldBeAsExpected(float p1, float p2, float expectedResult)
    {
        Assert.That(ArithmeticalOperations.Subtraction(p1, p2), Is.EqualTo(expectedResult));
    }

    [TestCase(2, 2, 1)]
    public void TestDivision_ValidArgs_ShouldBeAsExpected(float p1, float p2, float expectedResult)
    {
        Assert.That(ArithmeticalOperations.Division(p1, p2), Is.EqualTo(expectedResult));
    }

    [TestCase(2, 0)]
    public void TestDivision_DivideOnZero_ShouldNotThrow(float p1, float p2)
    {
        Assert.Throws<InvalidCommandArgumentException>(() => ArithmeticalOperations.Division(p1, p2));
    }

    [TestCase(4, 2)]
    [TestCase(0, 0)]
    public void TestSquareRoot_ValidArg_ShouldBeAsExpected(float p, float expectedResult)
    {
        Assert.That(ArithmeticalOperations.SquareRoot(p), Is.EqualTo(expectedResult));
    }

    [TestCase(-2)]
    public void TestSquareRoot_NegativeArg_ShouldThrow(float p)
    {
        Assert.Throws<InvalidCommandArgumentException>(() => ArithmeticalOperations.SquareRoot(p));
    }
}