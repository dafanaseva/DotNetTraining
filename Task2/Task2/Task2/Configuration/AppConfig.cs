namespace Task2.Configuration;

internal sealed class AppConfig
{
    public string? ExitConsoleText { get; set; }
    public string? CommandPattern { get; set; }
    public Commands? Commands { get; set; }
}