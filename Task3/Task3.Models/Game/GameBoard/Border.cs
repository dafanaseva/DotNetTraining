namespace Task3.Models.Game.GameBoard;

internal static class Border
{
    private const int SidesCount = 2;
    public const int Width = 1;

    public static int GetFullLength(int length)
    {
        return length + SidesCount * Width;
    }
}