using Task2.Parse;

namespace Task2.Tests.ParseTests;

[TestFixture]
internal sealed class ParseCommandExceptionTests
{
    private const string Message = "message";

    [Test]
    public void ShouldHasMessage()
    {
        var systemUnderTests = new ParseCommandException(Message);

        Assert.That(systemUnderTests.Message, Is.EqualTo(Message));
    }
}