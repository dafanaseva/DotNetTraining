using Task3.Models.Exceptions;

namespace Task3.Models.GameProcess;

internal sealed record BoardConfig
{
    public int Width { get; }
    public int Height { get; }
    public int NumberOfMines { get; }

    public BoardConfig(int width, int height, int numberOfMines)
    {
        LessThenZeroArgumentException.ThrowIfLessThenZero(width);
        LessThenZeroArgumentException.ThrowIfLessThenZero(height);
        LessThenZeroArgumentException.ThrowIfLessThenZero(numberOfMines);

        if (numberOfMines >= width * height)
        {
            throw new OutOfBoundsArgumentException(
                $"An argument {nameof(numberOfMines)} {numberOfMines} can not be more than height: {height} * width: {width}");
        }

        Width = width;
        Height = height;
        NumberOfMines = numberOfMines;
    }
}