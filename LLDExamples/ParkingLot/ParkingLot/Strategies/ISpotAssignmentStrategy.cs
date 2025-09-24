using ParkingLot.Model;

namespace ParkingLot.Strategies;

public interface ISpotAssignmentStrategy
{
    ParkingSpot? FindSpot(List<ParkingFloor> floors, Vehicle vehicle);
}