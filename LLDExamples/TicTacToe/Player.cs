using System;

namespace TicTacToe
{
    public class Player
    {
        public string name;
        public char marker;

        public Player(string name, char marker)
        {
            this.name = name;
            this.marker = marker;
        }
    }
}