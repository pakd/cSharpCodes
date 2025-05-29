using System;
using System.Collections.Generic;

namespace ElevatorSystem
{
    public class InternalButton : Button
    {
        private InternalDispatcher idispatcher;
        private List<int> floors = new List<int>();

        public InternalButton()
        {
            idispatcher = new InternalDispatcher();
        }

        public List<int> GetFloors()
        {
            return floors;
        }

        public void PressButton(int floor, Direction dir, int elevatorId)
        {
            floors.Add(floor);
            Console.WriteLine("Pressed floor " + floor + " from elevator " + elevatorId);
            idispatcher.SubmitRequest(floor, dir, elevatorId);
        }
    }
}