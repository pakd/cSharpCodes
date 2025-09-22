using System;
using System.Threading;
using SnakeAndFoodGame;

namespace SnakeAndFoodGame
{
    public class GameSession
    {
        private Game _game;
        private int _width;
        private int _height;

        public GameSession(int width, int height)
        {
            _width = width;
            _height = height;
            _game = new Game(width, height);
        }

        public void Start()
        {
            bool gameOver = false;
            Direction direction = Direction.Right;

            Console.Clear();
            Console.WriteLine("Welcome to the Snake and Food game!");

            while (!gameOver)
            {
                // 1. Read key input
                while (Console.KeyAvailable) // drain buffer
                {
                    var key = Console.ReadKey(intercept: true).Key;
                    direction = key switch
                    {
                        ConsoleKey.UpArrow => Direction.Up,
                        ConsoleKey.DownArrow => Direction.Down,
                        ConsoleKey.LeftArrow => Direction.Left,
                        ConsoleKey.RightArrow => Direction.Right,
                        _ => direction
                    };
                }

                // 2. Move snake
                if (!_game.MoveSnake(direction))
                {
                    gameOver = true;
                    break;
                }

                // 3. Render board
                DrawBoard();

                // 4. Wait for next frame
                Thread.Sleep(500);
            }

            Console.WriteLine($"Game Over! Your Score: {_game.Score}");
        }

        private void DrawBoard()
        {
            Console.Clear();

            var snakePosition = _game.GetSnake();
            var food = _game.GetFood();

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    bool isSnake = false;
                    foreach (var point in snakePosition)
                    {
                        if (point.X == x && point.Y == y)
                        {
                            isSnake = true;
                            break;
                        }
                    }

                    if (isSnake)
                    {
                        Console.Write('S');
                    }
                    else if (food != null && food.Position.X == x && food.Position.Y == y)
                    {
                        Console.Write(food is BonusFood ? 'B' : 'F');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Score: {_game.Score}");
        }
    }
}