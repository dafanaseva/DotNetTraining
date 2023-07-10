using Task3.Models.Exceptions;

namespace Task3.Models.GameBoard;

internal sealed record BoardConfig
{
    public int Width { get; }
    public int Height { get; }
    public int NumberOfMines { get; }
    public int  Seed { get; }

    public BoardConfig(int width, int height, int numberOfMines, int seed)
    {
        AssertParameter(width);
        AssertParameter(height);
        AssertParameter(numberOfMines);

        if (numberOfMines >= width * height)
        {
            throw new OutOfBoundsArgumentException(
                $"An argument {nameof(numberOfMines)} {numberOfMines} can not be more than height: {height} * width: {width}");
        }

        Width = width;
        Height = height;
        NumberOfMines = numberOfMines;
        Seed = seed;
    }

    private static void AssertParameter(int value)
    {
        LessThenZeroArgumentException.ThrowIfLessThenZero(value);
        OutOfBoundsArgumentException.ThrowIfEqualsToZero(value);
    }
}