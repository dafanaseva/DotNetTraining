namespace Task2.Create.Commands;

internal sealed class Multiplication : ArithmeticalCommand
{
    public Multiplication() : base(ArithmeticalOperations.Multiply)
    {
    }
}