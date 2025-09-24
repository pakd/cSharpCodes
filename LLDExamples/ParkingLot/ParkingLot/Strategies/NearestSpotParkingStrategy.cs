using ParkingLot.Model;

namespace ParkingLot.Strategies;

public class NearestSpotParkingStrategy : ISpotAssignmentStrategy
{
    public ParkingSpot? FindSpot(List<ParkingFloor> floors, Vehicle vehicle)
    {
        Console.WriteLine("[Debug] under FindSpot");
        // Iterate floors in ascending order (nearest/lowest floor first)
        foreach (var floor in floors)
        {
            Console.WriteLine($"[Debug] under Floor:{floor.FloorNumber}");
            // Find the first spot on this floor that fits the vehicle
            
            // Just for debug:
            foreach (var x in floor.ParkingSpots)
            {
                Console.WriteLine($"[Debug] SpotId:{x.SpotId}, Available:{x.IsAvailable}");
            }
            
            var spot = floor.ParkingSpots.FirstOrDefault(s => s.IsAvailable && s.CanFitVehicle(vehicle));
            if (spot != null)
                return spot;
        }

        // No available spot found across all floors
        return null;
    }
}