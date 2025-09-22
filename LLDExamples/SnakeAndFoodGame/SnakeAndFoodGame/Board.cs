namespace SnakeAndFoodGame;

public class Board
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Board(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public bool IsValidPosition(Point position)
    {
        return (position.X >= 0 && position.X < Width && position.Y >= 0 && position.Y < Height);
    }
}