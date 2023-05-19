namespace Task2.CreateCommands.Commands;

internal sealed class Addition : ArithmeticalCommand
{
    public Addition() : base(ArithmeticalOperations.Add)
    {
    }
}