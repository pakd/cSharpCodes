namespace ParkingLot.Model;

public enum VehicleType
{
    MOTORCYLE,
    CAR,
    SUV,
    TRUCK
}

public abstract class Vehicle
{
    public string LicensePlate { get; set; }
    public VehicleType Type { get; set; }

    protected Vehicle(string licensePlate, VehicleType type)
    {
        this.LicensePlate = licensePlate;
    }
}

public class Motorcylce : Vehicle
{
    public Motorcylce(string licensePlate) : base(licensePlate, VehicleType.MOTORCYLE)
    {
    }
}


public class Car : Vehicle
{
    public Car(string licensePlate) : base(licensePlate, VehicleType.CAR)
    {
    }
}

public class Suv : Vehicle
{
    public Suv(string licensePlate) : base(licensePlate, VehicleType.SUV)
    {
    }
}

public class Truck : Vehicle
{
    public Truck(string licensePlate) : base(licensePlate, VehicleType.TRUCK)
    {
    }
}