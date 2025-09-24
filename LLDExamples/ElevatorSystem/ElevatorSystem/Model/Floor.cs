using ElevatorSystem.Service;

namespace ElevatorSystem.Model;

public class Floor
{
    public int FloorNumber { get; set; }
    public FloorButtonPanel FloorButtonPanelRef { get; set; }

    public Floor(int floorNumber, Dispatcher dispatcher)
    {
        this.FloorNumber = floorNumber;
        FloorButtonPanelRef = new FloorButtonPanel(floorNumber, dispatcher);
    }
}