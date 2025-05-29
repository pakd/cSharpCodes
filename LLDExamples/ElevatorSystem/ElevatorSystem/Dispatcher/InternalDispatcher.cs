namespace ElevatorSystem
{
    public class InternalDispatcher
    {
        public void SubmitRequest(int floor, Direction dir, int elevatorId)
        {
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