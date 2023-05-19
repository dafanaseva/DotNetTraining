namespace Task2.CreateCommands.Commands;

internal sealed class Subtraction : ArithmeticalCommand
{
    public Subtraction() : base(ArithmeticalOperations.Subtract)
    {
    }
}