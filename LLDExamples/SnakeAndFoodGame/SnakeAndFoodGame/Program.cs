using SnakeAndFoodGame;

class Program
{
    public static void Main()
    {
        int width = 20;
        int height = 5;

        var session = new GameSession(width, height);
        session.Start();
    }
}