
namespace ParkingLot
{
    public class ParkingFloor
    {
        public string Name { get; set; }
        public Dictionary<ParkingSlotType, Dictionary<string, ParkingSlot>> ParkingSlots { get; set; }

        public ParkingFloor(string name, Dictionary<ParkingSlotType, Dictionary<string, ParkingSlot>> parkingSlots)
        {
            Name = name;
            ParkingSlots = parkingSlots;
        }

        public ParkingSlot GetRelevantSlotForVehicle(Vehicle vehicle)
        {
            VehicleCategory vehicleCategory = vehicle.VehicleCategory;
            ParkingSlotType parkingSlotType = PickCorrectSlot(vehicleCategory);

            if (!ParkingSlots.TryGetValue(parkingSlotType, out var relevantParkingSlots))
                return null;

            foreach (var kvp in relevantParkingSlots)
            {
                var slot = kvp.Value;
                if (slot.IsAvailable)
                {
                    return slot;
                }
            }

            return null;
        }

        public ParkingSlot ParkVehicle(Vehicle vehicle)
        {
            var slot = GetRelevantSlotForVehicle(vehicle);
            if (slot != null)
            {
                slot.AddVehicle(vehicle);
            }
            return slot;
        }

        private ParkingSlotType PickCorrectSlot(VehicleCategory vehicleCategory)
        {
            return vehicleCategory switch
            {
                VehicleCategory.TwoWheeler => ParkingSlotType.TwoWheeler,
                VehicleCategory.Hatchback or VehicleCategory.Sedan => ParkingSlotType.Compact,
                VehicleCategory.SUV => ParkingSlotType.Medium,
                VehicleCategory.Bus => ParkingSlotType.Large,
                _ => throw new ArgumentException("Unknown vehicle category", nameof(vehicleCategory))
            };
        }
    }
}