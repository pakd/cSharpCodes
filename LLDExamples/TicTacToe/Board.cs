namespace TicTacToe
{
    public class Board
    {
        private char[,] grid;
        public int size;

        public Board(int size)
        {
            this.size = size;
            grid = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }
        
        public bool IsValidMove(int row, int col)
        {
            if (row < 0 || row >= size || col < 0 || col >= size || grid[row, col] != ' ')
            {
                return false;
            }

            return true;
        }
        
        public void MakeMove(int row, int col, char symbol)
        {
            grid[row, col] = symbol;
        }
        
        public void Display()
        {
            Console.WriteLine("\nCurrent Board:");
            for (int i = 0; i < size; i++)
            {
                Console.Write(" ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write(grid[i, j]);
                    if (j < size - 1) Console.Write(" | ");
                }
                Console.WriteLine();
                if (i < size - 1)
                {
                    for (int k = 0; k < size * 4 - 3; k++) Console.Write("-");
                    Console.WriteLine();
                }
            }
        }
        
        
        public bool CheckWin(int row, int col, char symbol)
        {
            return CheckLine(row, 0, 0, 1, symbol) || // Row
                   CheckLine(0, col, 1, 0, symbol) || // Column
                   (row == col && CheckLine(0, 0, 1, 1, symbol)) || // Diagonal \
                   (row + col == size - 1 && CheckLine(0, size - 1, 1, -1, symbol)); // Diagonal /
        }
        
        private bool CheckLine(int startRow, int startCol, int rowInc, int colInc, char symbol)
        {
            for (int i = 0; i < size; i++)
            {
                int r = startRow + i * rowInc;
                int c = startCol + i * colInc;
                if (grid[r, c] != symbol)
                    return false;
            }
            return true;
        }
        
        public bool IsFull()
        {
            foreach (char c in grid)
                if (c == ' ') return false;
            return true;
        }
    }
}