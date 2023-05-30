namespace Task3.Models;

internal sealed record Cell(bool IsMined)
{
    public int? NumberOfMines { get; set; }
    public bool IsOpen { get; set; }
    public bool IsMined { get; set; } = IsMined;

    public string GetValue()
    {
        if (!IsOpen)
        {
            return string.Empty;
        }

        return IsMined ? "X" : $"{NumberOfMines}";
    }
}