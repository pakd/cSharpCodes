namespace ParkingLot.Model;

public class Ticket
{
    public string TicketId { get; set; }
    public Vehicle VehicleRef { get; set; }
    public ParkingSpot ParkingSpotRef { get; set; }
    public DateTime EntryTime { get; set; }
    public DateTime ExitTime { get; set; }

    public Ticket(string ticketId, Vehicle vehicleRef, ParkingSpot parkingSpotRef)
    {
        TicketId = ticketId;
        VehicleRef = vehicleRef;
        ParkingSpotRef = parkingSpotRef;
        EntryTime = DateTime.Now;
    }

    public void CloseTicket()
    {
        ExitTime = DateTime.Now;
    }
    
}