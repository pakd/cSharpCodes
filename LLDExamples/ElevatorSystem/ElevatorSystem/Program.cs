// See https://aka.ms/new-console-template for more information
using ElevatorSystem.Model;
using ElevatorSystem.Service;
namespace ElevatorSystem;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to ElevatorSystem!");


        ElevatorySystem elevatorSystem = new ElevatorySystem(10, 2);


        // External requests
        Console.WriteLine("External request at floor 3 UP");
        var assigned1 = elevatorSystem.Floors[3].FloorButtonPanelRef.DispatchRequest( Direction.UP);
        Console.WriteLine($"Elevator{assigned1.ElevatorId} assigned to floor 3: Current floor {assigned1.CurrentFloor}");


        // Simulate internal requests
        assigned1.ElevatorButtonPanelRef.RequestFloor(7);


        // Run simulation for 10 steps
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"\nStep {i + 1}:");
            elevatorSystem.StepAll();
            Thread.Sleep(500);
        }


        Console.WriteLine("Simulation finished.");
    }
}
