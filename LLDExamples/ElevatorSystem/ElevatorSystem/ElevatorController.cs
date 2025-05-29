using System;

namespace ElevatorSystem
{
    public class ElevatorController
    {
        private int id;
        private ElevatorCar elevatorCar;

        public ElevatorController(int id)
        {
            this.id = id;
            elevatorCar = new ElevatorCar(id);
        }

        public int GetId()
        {
            return id;
        }

        public ElevatorCar GetElevatorCar()
        {
            return elevatorCar;
        }

        public void AcceptRequest(int floor, Direction dir)
        {
            ElevatorSystem.elevatorControlStrategy.GetPendingRequestList().Enqueue(new PendingRequests(floor, dir));

            ControlCar();
        }

        private void ControlCar()
        {
            ElevatorSystem.elevatorControlStrategy.MoveElevator(this);
            Console.WriteLine("Elevator moving...");
        }
    }
}