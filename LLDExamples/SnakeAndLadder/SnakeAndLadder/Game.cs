namespace SnakeAndLadder
{
    class Game
    {
        private readonly Board board;
        private readonly Queue<Player> playersQueue;
        private readonly Dictionary<Player, int> playerPositions;
        private readonly Dice dice;
        private readonly int winningPosition;

        public Game(List<Player> players, Board board, int diceCount, int winningPosition)
        {
            this.board = board;
            this.winningPosition = winningPosition;
            this.dice = new Dice(diceCount);

            playersQueue = new Queue<Player>(players);
            playerPositions = new Dictionary<Player, int>();

            foreach (var player in players)
            {
                playerPositions[player] = 1; // Starting position
            }
        }

        public void Start()
        {
            Console.WriteLine($"Game started! Winning position is {winningPosition}.\n");

            while (true)
            {
                Player currentPlayer = playersQueue.Dequeue();
                int currentPosition = playerPositions[currentPlayer];

                Console.WriteLine($"{currentPlayer.Name}'s turn. Press Enter to roll {dice.diceCount} dice...");
                Console.ReadLine();

                int rollValue = dice.GetDiceValue();
                Console.WriteLine($"{currentPlayer.Name} rolled a total of: {rollValue}");

                int tentativePosition = currentPosition + rollValue;

                if (tentativePosition > winningPosition)
                {
                    Console.WriteLine(
                        $"{currentPlayer.Name} rolled beyond the winning position. Staying at {currentPosition}.\n");
                }
                else
                {
                    int newPosition = board.GetNewPosition(tentativePosition);

                    if (newPosition < tentativePosition)
                        Console.WriteLine("Oops! Bitten by a snake 🐍.");
                    else if (newPosition > tentativePosition)
                        Console.WriteLine("Yay! Climbed a ladder 🪜.");

                    playerPositions[currentPlayer] = newPosition;
                    Console.WriteLine($"{currentPlayer.Name} moved to position {newPosition}.\n");

                    if (newPosition == winningPosition)
                    {
                        Console.WriteLine($"{currentPlayer.Name} wins the game!");
                        break;
                    }
                }

                playersQueue.Enqueue(currentPlayer);
            }
        }
    }
}