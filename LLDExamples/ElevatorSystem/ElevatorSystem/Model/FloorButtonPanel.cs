using ElevatorSystem.Service;

namespace ElevatorSystem.Model;

public enum Direction
{
    UP,
    DOWN,
    IDLE
}

public class FloorButtonPanel
{
    private int _floor;
    private Dispatcher _dispatcher;

    public FloorButtonPanel(int floor, Dispatcher dispatcher)
    {
        this._floor = floor;
        this._dispatcher = dispatcher;
    }

    public ElevatorCar DispatchRequest( Direction direction)
    {
        return _dispatcher.DispatchRequest(_floor, direction);
    }

}