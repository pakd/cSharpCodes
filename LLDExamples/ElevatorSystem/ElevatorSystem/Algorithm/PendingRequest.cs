namespace ElevatorSystem
{
    public class PendingRequests
    {
        private int floor;
        private Direction dir;

        public PendingRequests(int floor, Direction dir)
        {
            this.floor = floor;
            this.dir = dir;
        }

        public int GetFloor()
        {
            return floor;
        }

        public Direction GetDirection()
        {
            return dir;
        }
    }
}