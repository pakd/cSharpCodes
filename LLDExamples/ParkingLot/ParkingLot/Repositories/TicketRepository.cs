using ParkingLot.Model;

namespace ParkingLot.Repositories;

public class TicketRepository
{
    public List<Ticket> Tickets { get; set; }

    public TicketRepository()
    {
        Tickets = new List<Ticket>();
    }
}