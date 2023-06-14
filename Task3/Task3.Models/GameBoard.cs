namespace Task3.Models;

internal sealed class GameBoard
{
    private Cell[,] Cells { get; }

    public int Width { get; }
    public int Height { get; }

    public GameBoard(int height, int width)
    {
        Width = width;
        Height = height;

        Cells = new Cell[width, height];

        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                Cells[i, j] = new Cell();
            }
        }
    }

    public Cell this[int x, int y] => Cells[x,y];
}