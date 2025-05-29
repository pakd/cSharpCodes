using System;

namespace ElevatorSystem
{
    public class ExternalDispatcher
    {
        public static readonly ExternalDispatcher INSTANCE = new ExternalDispatcher();

        private ExternalDispatcher()
        {
        }

        public void SubmitRequest(int floor, Direction dir)
        {
            int elevatorId = ElevatorSystem.elevatorSelectionStrategy.SelectElevator(floor, dir);
            Console.WriteLine("Selected elevator " + elevatorId);

            foreach (ElevatorController eController in ElevatorSystem.INSTANCE.GetElevatorControllerList())
            {
                if (eController.GetId() == elevatorId)
                {
                    eController.AcceptRequest(floor, dir);
                }
            }
        }
    }
}