namespace ParkingLot
{
    public class Ticket
    {
        public string TicketNumber { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
        public Vehicle Vehicle { get; set; }
        public ParkingSlot ParkingSlot { get; set; }

        private Ticket() { }

        public static Ticket CreateTicket(Vehicle vehicle, ParkingSlot parkingSlot)
        {
            long currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            return new Ticket
            {
                Vehicle = vehicle,
                ParkingSlot = parkingSlot,
                StartTime = currentTime,
                TicketNumber = vehicle.VehicleNumber + currentTime
            };
        }
    }
}