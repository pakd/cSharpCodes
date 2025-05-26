namespace SnakeAndLadder
{
    public class Program
    {
        public static void Main()
        {
            var snakes = new List<Jumper>
            {
                new Jumper(14, 7),
                new Jumper(31, 26),
                new Jumper(38, 20)
            };

            var ladders = new List<Jumper>
            {
                new Jumper(3, 22),
                new Jumper(5, 8),
                new Jumper(11, 26)
            };

            var board = new Board(snakes, ladders);

            var players = new List<Player>
            {
                new Player("Alice"),
                new Player("Bob"),
                new Player("Charlie")
            };

            int diceCount = 2;
            int winningPosition = 50;

            var game = new Game(players, board, diceCount, winningPosition);
            game.Start();

        }
    }
}

