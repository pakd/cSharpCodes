namespace ParkingLot.Model;


public enum SpotType
{
    SMALL,
    COMPACT,
    LARGE
}

public abstract class ParkingSpot
{
    public string SpotId { get; set; }
    public Vehicle? ParkedVehicle { get; set; }
    
    public bool IsAvailable => ParkedVehicle == null;
    
    public SpotType SpotType { get; set; }


    protected ParkingSpot(string spotId, SpotType spotType)
    {
        this.SpotId = spotId;
        this.SpotType = spotType;
    }
    
    public abstract bool CanFitVehicle(Vehicle vehicle);
}

public class SmallSpot : ParkingSpot
{
    public SmallSpot(string spotId) : base(spotId, SpotType.SMALL)
    {
    }

    public override bool CanFitVehicle(Vehicle vehicle)
    {
        return vehicle.Type == VehicleType.MOTORCYLE;
    }
}

public class CompactSpot : ParkingSpot
{
    public CompactSpot(string spotId) : base(spotId, SpotType.COMPACT)
    {
    }

    public override bool CanFitVehicle(Vehicle vehicle)
    {
        return vehicle.Type == VehicleType.MOTORCYLE || vehicle.Type == VehicleType.CAR;
    }
}

public class LargeSpot : ParkingSpot
{
    public LargeSpot(string spotId) : base(spotId, SpotType.LARGE)
    {
    }

    public override bool CanFitVehicle(Vehicle vehicle)
    {
        return vehicle.Type == VehicleType.MOTORCYLE 
               || vehicle.Type == VehicleType.CAR 
               || vehicle.Type == VehicleType.SUV 
               || vehicle.Type == VehicleType.TRUCK;
    }
}