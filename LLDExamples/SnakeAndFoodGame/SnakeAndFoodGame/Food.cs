namespace SnakeAndFoodGame;

public abstract class Food
{
    public Point Position { get; set; }
    public int Score { get; set; }

    public Food(Point position, int score)
    {
        Position = position;
        Score = score;
    }
}

public class NormalFood : Food
{
    public NormalFood(Point position) : base(position, 1) { }
}

public class BonusFood : Food
{
    public int Duration { get; set; } // in seconds

    public BonusFood(Point position, int duration) : base(position, 5)
    {
        Duration = duration;
    }
}
