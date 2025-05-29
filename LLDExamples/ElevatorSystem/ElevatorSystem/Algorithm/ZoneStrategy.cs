using System;

namespace ElevatorSystem
{
    public class ZoneStrategy : ElevatorSelectionStrategy
    {
        public override int SelectElevator(int floor, Direction dir)
        {
            foreach (ElevatorController eController in elevatorControllerList)
            {
                // assign elevators according to zones in building
                // out of these elevators select the elevator which is going in the same direction or is idle
            }

            // Fallback: return random elevator ID
            return new Random().Next(1, elevatorControllerList.Count);
        }
    }
}