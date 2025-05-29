using System.Collections.Generic;

namespace ElevatorSystem
{
    public class ElevatorSystem
    {
        private List<ElevatorController> elevatorControllerList = new List<ElevatorController>();

        public static ElevatorControlStrategy elevatorControlStrategy;
        public static ElevatorSelectionStrategy elevatorSelectionStrategy;

        public List<Floor> floors = new List<Floor>();

        // Singleton instance
        public static readonly ElevatorSystem INSTANCE = new ElevatorSystem();

        // Private constructor for singleton
        private ElevatorSystem()
        {
        }

        public List<ElevatorController> GetElevatorControllerList()
        {
            return elevatorControllerList;
        }

        public void AddElevator(ElevatorController e)
        {
            elevatorControllerList.Add(e);
        }

        public void RemoveElevator(ElevatorController e)
        {
            elevatorControllerList.Remove(e);
        }

        public void SetElevatorControlStrategy(ElevatorControlStrategy strategy)
        {
            elevatorControlStrategy = strategy;
        }

        public void SetElevatorSelectionStrategy(ElevatorSelectionStrategy strategy)
        {
            elevatorSelectionStrategy = strategy;
        }

        public void AddFloor(Floor floor)
        {
            floors.Add(floor);
        }
    }
}