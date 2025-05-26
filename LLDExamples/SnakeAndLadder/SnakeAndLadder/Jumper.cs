namespace SnakeAndLadder
{
    class Jumper
    {
        public int Start { get; }
        public int End { get; }

        public Jumper(int start, int end)
        {
            Start = start;
            End = end;
        }

        public bool IsSnake => Start > End;
        public bool IsLadder => Start < End;
        
    }

}