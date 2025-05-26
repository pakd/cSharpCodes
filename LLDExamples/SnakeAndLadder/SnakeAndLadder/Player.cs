namespace SnakeAndLadder
{
    class Player
    {
        public Guid Id { get; }        // Unique random ID
        public string Name { get; }

        public Player(string name)
        {
            Id = Guid.NewGuid();       // Generate random unique ID
            Name = name;
        }
    }
}