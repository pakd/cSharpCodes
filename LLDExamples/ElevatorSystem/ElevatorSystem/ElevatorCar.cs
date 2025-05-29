using System;

namespace ElevatorSystem
{
    public class ElevatorCar
    {
        private int id;
        private Door door;
        private Display display;
        private Button button;
        private int currentFloor;  //updated while elevator moves to each floor
        private Direction dir; //updated every time elevator hanges direction

        public ElevatorCar(int id)
        {
            this.id = id;
            door = new Door();
            display = new Display();
            currentFloor = 0;
            dir = Direction.IDLE;
            button = new InternalButton();
        }

        public int GetId()
        {
            return id;
        }

        public Door GetDoor()
        {
            return door;
        }

        public Display GetDisplay()
        {
            return display;
        }

        public Button GetButton()
        {
            return button;
        }

        public int GetCurrentFloor()
        {
            return currentFloor;
        }

        public void SetCurrentFloor(int floor)
        {
            currentFloor = floor;
        }

        public Direction GetDirection()
        {
            return dir;
        }

        public void Move(Direction dir, int floor)
        {
            //called everytime when currFloor value changes
            this.dir = dir;

            Console.WriteLine("Elevator " + id + "moving " + dir);
            Console.WriteLine("Elevator " + id + "stops at floor " + floor);

            SetCurrentFloor(floor); // update current floor before display

            door.Open(id);
            door.Close(id);

            SetDisplay();
        }

        public void PressButton(int floor)
        {
            Direction dir = Direction.IDLE;
            if (floor > currentFloor)
                dir = Direction.UP;
            else if (floor < currentFloor)
                dir = Direction.DOWN;
            button.PressButton(floor, dir, id);
        }

        private void SetDisplay()
        {
            display.SetFloor(currentFloor);
            display.SetDirection(dir);
        }
    }
}
