using Moq;
using Task2.Configuration;

namespace Task2.Tests.ConfigurationTests;

[TestFixture]
internal sealed class CommandsConfigTests
{
    [Test]
    public void CreateCommandsConfigTests_EmptyNamespace_ShouldBeOk()
    {
        var commandsConfig = new CommandsConfig
        {
            Namespace = string.Empty
        };

        Assert.IsNotNull(commandsConfig.Namespace);
    }
}