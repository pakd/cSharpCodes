namespace ElevatorSystem.Model;

public class ElevatorButtonPanel
{
    private ElevatorCar _elevatorCar;

    public ElevatorButtonPanel(ElevatorCar elevatorCar)
    {
        this._elevatorCar = elevatorCar;
    }

    public void RequestFloor(int floor)
    {
        _elevatorCar.AddRequest(floor);
    }
}