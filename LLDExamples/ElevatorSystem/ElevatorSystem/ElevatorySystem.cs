using ElevatorSystem.Model;
using ElevatorSystem.Service;

namespace ElevatorSystem;

public class ElevatorySystem
{
    public List<Floor> Floors;
    public List<ElevatorCar> ElevatorCars;
    public Dispatcher DispatcherObj;

    public ElevatorySystem(int numFloors, int numElevators)
    {
        ElevatorCars = new List<ElevatorCar>();
        for (int i = 0; i < numElevators; i++)
        {
            ElevatorCars.Add(new ElevatorCar(i));
        }
        
        DispatcherObj = new Dispatcher(ElevatorCars);
        
        Floors = new List<Floor>();
        for (int i = 0; i < numFloors; i++)
        {
            Floors.Add(new Floor(i, DispatcherObj));
        }
    }
    
    public void StepAll()
    {
        foreach (var car in ElevatorCars)
        {
            car.Step(); 
        }
            
    }
}