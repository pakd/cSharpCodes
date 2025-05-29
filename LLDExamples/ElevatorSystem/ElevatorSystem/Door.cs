using System;

namespace ElevatorSystem
{
    public class Door
    {
        public void Open(int id)
        {
            Console.WriteLine("Door opens for elevator " + id);
        }

        public void Close(int id)
        {
            Console.WriteLine("Door closes for elevator " + id);
        }
    }
}