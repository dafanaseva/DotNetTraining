using Task2.Configuration;

namespace Task2.Tests.ConfigurationTests;

[TestFixture]
internal sealed class AppConfigTests
{
    [TestCase(null, null)]
    [TestCase("", "")]
    [TestCase("([A-z])", "Task2")]
    public void CreateCommandsConfigTests_AnyProperties_ShouldBeOk(string? commandPattern, string? @nameSpace)
    {
        var commandsConfig = new AppConfig
        {
            CommandPattern = commandPattern,
            Namespace = nameSpace
        };

        Assert.That(commandsConfig, Is.Not.Null);
    }
}