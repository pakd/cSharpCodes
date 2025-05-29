using System;

namespace ElevatorSystem
{
    public class ExternalButton : Button
    {
        private ExternalDispatcher edispatcher = ExternalDispatcher.INSTANCE;
        private Direction direction;

        public Direction GetDirection()
        {
            return direction;
        }

        public void PressButton(int floor, Direction dir)
        {
            direction = dir;
            Console.WriteLine("Pressed " + direction + " from floor " + floor);
            edispatcher.SubmitRequest(floor, dir);
        }
    }
}