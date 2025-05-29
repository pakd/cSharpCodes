namespace ElevatorSystem
{
    public class Display
    {
        private int floor;
        private Direction dir;

        public int GetFloor()
        {
            return floor;
        }

        public void SetFloor(int floor)
        {
            this.floor = floor;
        }

        public Direction GetDirection()
        {
            return dir;
        }

        public void SetDirection(Direction dir)
        {
            this.dir = dir;
        }
    }

}