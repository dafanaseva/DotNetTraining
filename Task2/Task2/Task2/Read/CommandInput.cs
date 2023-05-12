namespace Task2.Read;

public class CommandInput
{
    public CommandInput(string name, object[] parameters)
    {
        Name = name;
        Parameters = parameters;
    }

    public string Name { get; }
    public object[] Parameters { get; }
}