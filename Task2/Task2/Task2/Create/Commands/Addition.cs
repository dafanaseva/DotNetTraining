namespace Task2.Create.Commands;

internal sealed class Addition : ArithmeticalCommand
{
    public Addition() : base(ArithmeticalOperations.Add)
    {
    }
}