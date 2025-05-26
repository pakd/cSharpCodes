using System;

namespace SnakeAndLadder
{
    class Board
    {
        public List<Jumper> Snakes { get; }
        public List<Jumper> Ladders { get; }

        public Board(List<Jumper> snakes, List<Jumper> ladders)
        {
            Snakes = snakes;
            Ladders = ladders;
        }

        // Given a position, returns the new position after snake/ladder effect
        public int GetNewPosition(int position)
        {
            foreach (var snake in Snakes)
            {
                if (snake.Start == position)
                    return snake.End; // move down
            }

            foreach (var ladder in Ladders)
            {
                if (ladder.Start == position)
                    return ladder.End; // move up
            }

            return position; // no snake or ladder at this position
        }
    }
}
