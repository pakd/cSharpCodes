using ElevatorSystem.Model;

namespace ElevatorSystem.Service;

public class Dispatcher
{
    private List<ElevatorCar> ElevatorCars;

    public Dispatcher(List<ElevatorCar> elevatorCars)
    {
        ElevatorCars = elevatorCars;
    }

    public ElevatorCar DispatchRequest(int requestedFromFloor, Direction direction)
    {
        ElevatorCar choosenCar = null;
        int bestScore = int.MaxValue; // more negative is the best

        foreach (var car in ElevatorCars)
        {
            // just calculate the distance in dumb mode
            int distance = Math.Abs(requestedFromFloor - car.CurrentFloor);
            int score = distance;
            
            // now check if the car was moving away
            if ((car.CurrentDirection == Direction.UP && requestedFromFloor < car.CurrentFloor) &&
                (car.CurrentDirection == Direction.DOWN && requestedFromFloor > car.CurrentFloor))
            {
                // Big penalty for moving away
                score += 1000;
            }

            if (car.CurrentDirection == Direction.IDLE)
            {
                // slight bonus for idle lifts
                score -= 10;
            }

            if (score < bestScore)
            {
                bestScore = score;
                choosenCar = car;
            }

        }
        
        choosenCar.AddRequest(requestedFromFloor);
        return choosenCar;
    }
}