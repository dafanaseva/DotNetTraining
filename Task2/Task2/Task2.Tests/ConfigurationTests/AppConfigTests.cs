﻿using Task2.Configuration;

namespace Task2.Tests.ConfigurationTests;

[TestFixture]
internal sealed class AppConfigTests
{
    [Test]
    public void CreateCommandsConfigTests_EmptyProperties_ShouldBeOk()
    {
        var commandsConfig = new AppConfig
        {
            CommandPattern = string.Empty
        };

        Assert.That(commandsConfig, Is.Not.Null);
    }
}