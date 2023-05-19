namespace Task2.CreateCommands.Commands;

internal sealed class Multiplication : ArithmeticalCommand
{
    public Multiplication() : base(ArithmeticalOperations.Multiply)
    {
    }
}