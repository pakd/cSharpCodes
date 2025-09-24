namespace ElevatorSystem.Model;

public class ElevatorCar
{
    public ElevatorButtonPanel ElevatorButtonPanelRef;
    public Direction CurrentDirection;
    public int CurrentFloor;
    public int ElevatorId { get; set; }

    private PriorityQueue<int, int> _upRequest; // min heap
    private PriorityQueue<int, int> _downRequest; // max heap
    
    
    public ElevatorCar(int id)
    {
        ElevatorButtonPanelRef = new ElevatorButtonPanel(this);
        CurrentFloor = 0;
        CurrentDirection = Direction.IDLE;
        _upRequest = new PriorityQueue<int, int>();
        _downRequest = new PriorityQueue<int, int>();
        this.ElevatorId = id;
    }

    // Add a new request to appropriate queue based on floor
    public void AddRequest(int floor)
    {
        Console.WriteLine($"[Debug] Elevator {ElevatorId} AddRequest: {floor}");
        
        if (floor == CurrentFloor)
        {
            // Already at requested floor
            Console.WriteLine($"[Debug] Elevator {ElevatorId} already at floor {floor}");
            return;
        }
        
        if (floor > CurrentFloor)
        {
            _upRequest.Enqueue(floor, floor);
        }
        else if (floor < CurrentFloor)
        {
            _downRequest.Enqueue(floor, -floor);
        }
        
        // If elevator is idle, set direction toward first request
        if (CurrentDirection == Direction.IDLE)
            CurrentDirection = (floor > CurrentFloor) ? Direction.UP : Direction.DOWN;
    }

    // Move elevator to a specific floor
    private void MoveTo(int floor)
    {
        Console.WriteLine($"Elevator moving from {CurrentFloor} to {floor}");
        Thread.Sleep(200); // Simulate movement delay
        CurrentFloor = floor;
        Console.WriteLine($"Elevator arrived at {CurrentFloor}");
    }

    // Get the next floor in a given direction
    public int? GetNextFloorInDirection(Direction direction)
    {
        if (direction == Direction.UP && _upRequest.Count > 0)
        {
            return _upRequest.Dequeue();
        }

        if (direction == Direction.DOWN && _downRequest.Count > 0)
        {
            return _downRequest.Dequeue();
        }

        return null;
    }

    public void Step()
    {
        Console.WriteLine($"[Debug] Inside Step of ElevatorCar:{ElevatorId}");
        int? nextFloor = GetNextFloorInDirection(CurrentDirection);

        if (nextFloor == null)
        {
            // switch direction, as we dont have any floor currently
            if (CurrentDirection == Direction.UP)
            {
                nextFloor = GetNextFloorInDirection(Direction.DOWN);
            }
            else if (CurrentDirection == Direction.DOWN)
            {
                nextFloor = GetNextFloorInDirection(Direction.UP);
            }
        }

        if (nextFloor != null)
        {
            CurrentDirection = (nextFloor > CurrentFloor) ? Direction.UP : Direction.DOWN;
            MoveTo(nextFloor.Value);
        }
        else
        {
            CurrentDirection = Direction.IDLE;
        }
        Console.WriteLine($"[Debug] Inside Step of ElevatorCar:{ElevatorId}, Direction: {CurrentDirection}");
    }
}