namespace ParkingLot.Model;

public class ParkingFloor
{
    public int FloorNumber { get; set; }
    public List<ParkingSpot> ParkingSpots { get; set; }

    public ParkingFloor(int floorNumber, List<ParkingSpot> parkingSpots)
    {
        FloorNumber = floorNumber;
        ParkingSpots = parkingSpots;
    }
}