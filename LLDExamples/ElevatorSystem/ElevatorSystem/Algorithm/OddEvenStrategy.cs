using System;

namespace ElevatorSystem
{
    public class OddEvenStrategy : ElevatorSelectionStrategy
    {
        public override int SelectElevator(int floor, Direction dir)
        {
            foreach (ElevatorController eController in elevatorControllerList)
            {
                // old elevator for odd floors and even elevators for even floors
                // select elevator which is moving in same direction which is requested or IDLE elevator
                // if (floor % 2 == eController.GetId() % 2)
                // {
                //     int currFloor = eController.GetElevatorCar().GetCurrentFloor();
                //     Direction currDir = eController.GetElevatorCar().GetDir();
                //     if (floor > currFloor && currDir == Direction.UP)
                //         return eController.GetId();
                //     else if (floor < currFloor && currDir == Direction.DOWN)
                //         return eController.GetId();
                //     else if (currDir == Direction.NONE)
                //         return eController.GetId();
                // }
            }

            // Fallback: return random elevator ID
            return new Random().Next(1, elevatorControllerList.Count);
        }
    }
}