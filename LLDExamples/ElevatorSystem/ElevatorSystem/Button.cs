namespace ElevatorSystem
{
    public class Button
    {
        // For External Button
        public void PressButton(int floor, Direction dir)
        {
            Console.WriteLine($"External button pressed at floor {floor} to go {dir}");
        }

        // For Internal Button
        public void PressButton(int floor, Direction dir, int elevatorId)
        {
            Console.WriteLine($"Internal button pressed in elevator {elevatorId} to go to floor {floor} ({dir})");
        }
    }
}