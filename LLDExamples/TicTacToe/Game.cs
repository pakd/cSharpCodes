namespace TicTacToe
{
    public class Game
    {
        private Player player1;
        private Player player2;
        private Board board;

        public Game(Board board, Player player1, Player player2)
        {
            this.board = board;
            this.player1 = player1;
            this.player2 = player2;
        }
        
        public void Start()
        {
            Player currentPlayer = player1;
            while (true)
            {
                board.Display();
                (int row, int col) = GetValidatedMove(board.size);

                if (!board.IsValidMove(row, col))
                {
                    Console.WriteLine("Invalid move. Try again.");
                    continue;
                }

                board.MakeMove(row, col, currentPlayer.marker);

                if (board.CheckWin(row, col, currentPlayer.marker))
                {
                    board.Display();
                    Console.WriteLine($"{currentPlayer.marker} wins!");
                    break;
                }

                if (board.IsFull())
                {
                    board.Display();
                    Console.WriteLine("It's a draw!");
                    break;
                }

                currentPlayer = currentPlayer == player1 ? player2 : player1;
            }
        }
        
        private (int, int) GetValidatedMove(int n)
        {
            while (true)
            {
                Console.Write($"Enter your move (row,column) between 1 and {n}: ");
                string input = Console.ReadLine();

                // Check basic format
                if (string.IsNullOrWhiteSpace(input) || !input.Contains(","))
                {
                    Console.WriteLine("Invalid format. Use row,column format like 2,3.");
                    continue;
                }

                string[] parts = input.Split(',');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid input. Please enter exactly two numbers separated by a comma.");
                    continue;
                }

                // Try parsing both parts
                bool isRowValid = int.TryParse(parts[0], out int row);
                bool isColValid = int.TryParse(parts[1], out int col);

                if (!isRowValid || !isColValid)
                {
                    Console.WriteLine("Invalid numbers. Make sure to enter numeric values like 2,3.");
                    continue;
                }

                // Convert to 0-based index
                row--;
                col--;

                // Check bounds
                if (row < 0 || row >= n || col < 0 || col >= n)
                {
                    Console.WriteLine($"Numbers must be between 1 and {n}.");
                    continue;
                }

                return (row, col);
            }
        }
    }
}