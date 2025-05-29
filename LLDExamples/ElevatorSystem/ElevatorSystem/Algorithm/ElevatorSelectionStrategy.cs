using System.Collections.Generic;

namespace ElevatorSystem
{
    public class ElevatorSelectionStrategy
    {
        protected List<ElevatorController> elevatorControllerList = ElevatorSystem.INSTANCE.GetElevatorControllerList();

        public virtual int SelectElevator(int floor, Direction dir)
        {
            return 0;
        }
    }
}