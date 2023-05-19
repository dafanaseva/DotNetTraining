using Task2.Parse;

namespace Task2.Tests.ParseTests;

[TestFixture]
internal sealed class CommandDataTests
{
    private static readonly object[][] ValidParameters = { Array.Empty<object>(), new[] { (object)"a" } };

    [TestCaseSource(nameof(ValidParameters))]
    public void TestCreateCommandData_ShouldBeOk(object[] parameters)
    {
        var data = new CommandData("command", new object[] { "parameter" });

        Assert.That(data, Is.Not.Null);
    }

    [TestCase("")]
    [TestCase(null)]
    public void TestCreateCommandData_EmptyParameters_ShouldBeOk(string commandName)
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            // ReSharper disable once ObjectCreationAsStatement
            new CommandData(commandName, Array.Empty<object>());
        });
    }
}