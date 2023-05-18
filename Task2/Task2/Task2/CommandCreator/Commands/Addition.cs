namespace Task2.CommandCreator.Commands;

internal sealed class Addition : ArithmeticalCommand
{
    public Addition() : base(ArithmeticalOperation.Addition)
    {
    }
}