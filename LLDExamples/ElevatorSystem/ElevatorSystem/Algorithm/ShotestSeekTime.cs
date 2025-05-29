namespace ElevatorSystem
{
    public class ShortestSeekTime : ElevatorControlStrategy
    {
        public override void MoveElevator(ElevatorController elevatorController)
        {
            // implemented using min heap which is sorted according to
            // min distance of requested floor from the current floor of elevator

            // this min heap is updated every time a new request is added in the queue or
            // when elevator moves to another floor

            // Disadvantage: starvation of distant floor when maximum requests keep coming from nearby floors
        }
    }
}