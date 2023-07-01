namespace Task3.Models.Game;

internal sealed record GameConfig
{
    // todo: assert more then 0, less then ...
    public int BoardWidth { get; set; }
    public int BoardHeight { get; set; }
    public int NumberOfMines { get; set; }
}