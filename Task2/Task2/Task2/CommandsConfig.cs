namespace Task2;

internal sealed class CommandsConfig
{
    public string Namespace { get; set; }
    public List<CommandConfig> Commands { get; set; }

    public Dictionary<string, Type?> ToDictionary()
    {
        return Commands?.ToDictionary(
            t => t.Name,
            t => Type.GetType($"{Namespace}.{t.Class}")) ?? new Dictionary<string, Type?>();
    }
}

internal sealed class CommandConfig
{
    public string Name { get; set; }
    public string Class { get; set; }
}