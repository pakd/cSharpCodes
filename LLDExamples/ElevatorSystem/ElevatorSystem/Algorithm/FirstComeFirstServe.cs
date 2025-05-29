namespace ElevatorSystem
{
    public class FirstComeFirstServe : ElevatorControlStrategy
    {
        public override void MoveElevator(ElevatorController elevatorController)
        {
            // poll each request out of queue one by one
            // move elevator according to each request
            // Disadvantage: frequent change of direction of elevator, hence inefficient and
            // long waiting time for users
        }
    }
}