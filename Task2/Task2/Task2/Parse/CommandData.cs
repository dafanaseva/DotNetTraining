namespace Task2.Parse;

internal sealed record CommandData(string Name, object[] Parameters)
{
    public string Name { get; } = string.IsNullOrEmpty(Name) ? throw new ArgumentNullException(nameof(Name)) : Name;

    public object[] Parameters { get; } = Parameters;

    public void Deconstruct(out string name, out object[] parameters)
    {
        name = Name;
        parameters = Parameters;
    }
}