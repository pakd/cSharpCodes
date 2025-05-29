using System.Collections.Generic;

namespace ElevatorSystem
{
    public class ElevatorControlStrategy
    {
        // queue storing pending requests in form of
        private Queue<PendingRequests> pendingRequestList = new Queue<PendingRequests>();
        private List<ElevatorController> elevatorControllerList = ElevatorSystem.INSTANCE.GetElevatorControllerList();

        public Queue<PendingRequests> GetPendingRequestList()
        {
            return pendingRequestList;
        }

        public void SetPendingRequestList(Queue<PendingRequests> list)
        {
            pendingRequestList = list;
        }

        public List<ElevatorController> GetElevatorControllerList()
        {
            return elevatorControllerList;
        }

        public virtual void MoveElevator(ElevatorController elevatorController)
        {
            // logic to be implemented by subclass or caller
        }
    }
}