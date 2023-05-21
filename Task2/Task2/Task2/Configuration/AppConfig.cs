namespace Task2.Configuration;

internal sealed class AppConfig
{
    public string? CommandPattern { get; set; }
    public string? Namespace { get; set; }
    public Dictionary<string, string>? CommandNameClassName { get; set; }
}