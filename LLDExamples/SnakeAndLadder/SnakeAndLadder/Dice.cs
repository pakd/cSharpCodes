namespace SnakeAndLadder
{
    class Dice
    {
        private readonly Random random;

        public int diceCount;

        public Dice(int diceCount)
        {
            this.diceCount = diceCount;
            random = new Random();
        }

        // Rolls 'count' number of dice and returns the total value
        public int GetDiceValue()
        {
            int total = 0;
            for (int i = 0; i < this.diceCount; i++)
            {
                int roll = random.Next(1, 7); // Dice face: 1 to 6
                total += roll;
            }
            return total;
        }
    }
}