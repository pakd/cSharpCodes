namespace ParkingLot
{
    public class ParkingLot
    {
        private string NameOfParkingLot;
        private Address Address;
        private List<ParkingFloor> ParkingFloors;
        private static ParkingLot _instance = null;
        private static readonly object _lock = new object();

        private ParkingLot(string nameOfParkingLot, Address address, List<ParkingFloor> parkingFloors)
        {
            NameOfParkingLot = nameOfParkingLot;
            Address = address;
            ParkingFloors = parkingFloors;
        }

        public static ParkingLot GetInstance(string nameOfParkingLot, Address address, List<ParkingFloor> parkingFloors)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ParkingLot(nameOfParkingLot, address, parkingFloors);
                    }
                }
            }

            return _instance;
        }

        public void AddFloor(string name, Dictionary<ParkingSlotType, Dictionary<string, ParkingSlot>> parkSlots)
        {
            ParkingFloor parkingFloor = new ParkingFloor(name, parkSlots);
            ParkingFloors.Add(parkingFloor);
        }

        public void RemoveFloor(ParkingFloor parkingFloor)
        {
            ParkingFloors.Remove(parkingFloor);
        }

        public Ticket AssignTicket(Vehicle vehicle)
        {
            ParkingSlot parkingSlot = GetParkingSlotForVehicleAndPark(vehicle);
            if (parkingSlot == null) return null;

            Ticket parkingTicket = CreateTicketForSlot(parkingSlot, vehicle);
            // Persist ticket to database (not implemented)
            return parkingTicket;
        }

        public double ScanAndPay(Ticket ticket)
        {
            long endTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            ticket.ParkingSlot.RemoveVehicle(ticket.Vehicle);

            int durationInSeconds = (int)((endTime - ticket.StartTime) / 1000);
            double price =
                ParkingSlotPricing.GetPriceForParking(ticket.ParkingSlot.ParkingSlotType, durationInSeconds);

            // Persist record to database (not implemented)
            return price;
        }

        private Ticket CreateTicketForSlot(ParkingSlot parkingSlot, Vehicle vehicle)
        {
            return Ticket.CreateTicket(vehicle, parkingSlot);
        }

        private ParkingSlot GetParkingSlotForVehicleAndPark(Vehicle vehicle)
        {
            foreach (var floor in ParkingFloors)
            {
                var slot = floor.ParkVehicle(vehicle);
                if (slot != null) return slot;
            }

            return null;
        }
    }
}