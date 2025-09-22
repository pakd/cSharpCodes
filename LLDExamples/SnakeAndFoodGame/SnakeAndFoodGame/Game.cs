namespace SnakeAndFoodGame;

using System.Threading.Tasks;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class Game
{
    private Board _board;
    private Snake _snake;
    private Food _currentFood;
    private Random _random;
    public int Score { get; set; }
    
    private bool _isGameOver;

    public Game(int width, int height)
    {
        _board = new Board(width, height);
        _snake = new Snake(new Point(0, height/2));
        _random = new Random();
        SpawnFood();
    }

    private async void SpawnFood()
    {
        Point foodPos;
        do
        {
            foodPos = new Point(_random.Next(0, _board.Width), _random.Next(0, _board.Height));
        } while (_snake.IsCollision(foodPos));

        if (_random.NextDouble() < 0.2) // 20% chance for bonus food
        {
            var bonusFood = new BonusFood(foodPos, 5); // 5 seconds duration
            _currentFood = bonusFood;

            // Run a 5-second timer asynchronously
            _ = Task.Run(async () =>
            {
                await Task.Delay(bonusFood.Duration * 1000);

                // Only remove it if it is still on the board (not eaten yet)
                if (_currentFood == bonusFood)
                {
                    _currentFood = null;
                    // Spawn a new food (normal or bonus)
                    SpawnFood();
                }
            });
        }
        else
        {
            _currentFood = new NormalFood(foodPos);
        }
    }

    public bool MoveSnake(Direction direction)
    {
        Point head = _snake.GetHeadPosition();


        Point newPoint = null;

        switch (direction)
        {
            case Direction.Up:
                newPoint = new Point(head.X, head.Y-1);
                break;
            case Direction.Down:
                newPoint = new Point(head.X, head.Y+1);
                break;
            case Direction.Left:
                newPoint = new Point(head.X-1, head.Y);
                break;
            case Direction.Right:
                newPoint = new Point(head.X+1, head.Y);
                break;
        }

        if (!_board.IsValidPosition(newPoint) || _snake.IsCollision(newPoint))
        {
            Console.WriteLine($"Your Game is Over, Your Score: {Score}");
            return false;
        }
        
        bool grow = (_currentFood.Position.X == newPoint.X && _currentFood.Position.Y == newPoint.Y);

        if (grow)
        {
            Score += _currentFood.Score;
            SpawnFood();
        }
        
        // Actually move the snake
        _snake.Move(newPoint, grow);
        return true;
    }

    public List<Point> GetSnake()
    {
        return _snake.GetSnakePositions();
    }

    public Food GetFood()
    {
        return _currentFood;
    }
}