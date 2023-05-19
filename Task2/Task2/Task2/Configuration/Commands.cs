namespace Task2.Configuration;

// ReSharper disable once ClassNeverInstantiated.Global
internal sealed class Commands
{
    public string? Namespace { get; set; }
    // ReSharper disable once CollectionNeverUpdated.Local
    private Dictionary<string, string>? CommandNameClassName { get; } = new();

    public Dictionary<string, Type?> ToDictionary()
    {
        return CommandNameClassName?.ToDictionary(
                   t => t.Key,
                   t => Type.GetType($"{Namespace}.{t.Value}")) ??
               new Dictionary<string, Type?>();
    }
}