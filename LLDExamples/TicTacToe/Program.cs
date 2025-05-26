
namespace TicTacToe
{
    public class Program
    {
        public static void Main()
        {

            Board board = new Board(3);
            Player player1 = new Player("Foo", 'x');
            Player player2 = new Player("Bar", 'o');
            
            Game game  = new Game(board, player1, player2);
            game.Start();
            Console.WriteLine("Welcome to TicTacToe!");
        }
    }
}
