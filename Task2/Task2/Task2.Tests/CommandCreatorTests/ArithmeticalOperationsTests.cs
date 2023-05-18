using Task2.CommandCreator;

namespace Task2.Tests.CommandCreatorTests;

[TestFixture]
internal sealed class ArithmeticalOperationsTests
{
    [TestCase(1, 2, 3)]
    [TestCase(2, 1, 3)]
    public void TestAddition_ValidArgs_ShouldBeAsExpected(float p1, float p2, float expectedResult)
    {
        Assert.AreEqual(expectedResult, ArithmeticalOperations.Addition(p1, p2));
    }

    [TestCase(1, 2, 2)]
    [TestCase(2, 1, 2)]
    [TestCase(0, 1, 0)]
    public void TestMultiplication_ValidArgs_ShouldBeAsExpected(float p1, float p2, float expectedResult)
    {
        Assert.AreEqual(expectedResult, ArithmeticalOperations.Multiplication(p1, p2));
    }

    [TestCase(2, 2, 0)]
    [TestCase(0, 1, -1)]
    [TestCase(-1, -1, 0)]
    public void TestSubtraction_ValidArgs_ShouldBeAsExpected(float p1, float p2, float expectedResult)
    {
        Assert.AreEqual(expectedResult, ArithmeticalOperations.Subtraction(p1, p2));
    }


    [TestCase(2, 2, 1)]
    public void TestDivision_ValidArgs_ShouldBeAsExpected(float p1, float p2, float expectedResult)
    {
        Assert.AreEqual(expectedResult, ArithmeticalOperations.Division(p1, p2));
    }

    [TestCase(2, 0, 1)]
    public void TestDivision_DivideOnZero_ShouldNotThrow(float p1, float p2, float expectedResult)
    {
        Assert.Throws<DivideByZeroException>(() => ArithmeticalOperations.Division(p1, p2));
    }

    [TestCase(4, 2)]
    [TestCase(0, 0)]
    [TestCase(-4, float.NaN)]
    public void TestDivision_ValidArgs_ShouldBeAsExpected(float p, float expectedResult)
    {
        Assert.AreEqual(expectedResult, ArithmeticalOperations.SquareRoot(p));
    }
}