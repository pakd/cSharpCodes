namespace ParkingLot
{
    public class ParkingSlot
    {
        public string Name;

        public bool IsAvailable;

        Vehicle Vehicle;

        public ParkingSlotType ParkingSlotType;

        public ParkingSlot(string name, ParkingSlotType parkingSlotType)
        {
            this.Name = name;
            this.IsAvailable = true;
            this.ParkingSlotType = parkingSlotType;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            this.Vehicle = vehicle;
            this.IsAvailable = false;
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            this.Vehicle = null;
            this.IsAvailable = true;
        }
    }
}