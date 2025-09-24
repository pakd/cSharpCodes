using ParkingLot.Model;
using ParkingLot.Repositories;
using ParkingLot.Strategies;

namespace ParkingLot;

public class ParkingLot
{
    public string Name { get; set; }
    public List<ParkingFloor> ParkingFloors { get; set; }
    private TicketRepository ticketRepository;
    private ISpotAssignmentStrategy _spotAssignmentStrategy;
    private IPricingStrategy _pricingStrategy;

    public ParkingLot(TicketRepository ticketRepository, ISpotAssignmentStrategy spotAssignmentStrategy, IPricingStrategy pricingStrategy, string name, List<ParkingFloor> parkingFloors)
    {
        this.ticketRepository = ticketRepository;
        _spotAssignmentStrategy = spotAssignmentStrategy;
        _pricingStrategy = pricingStrategy;
        Name = name;
        ParkingFloors = parkingFloors;
    }

    public Ticket? ParkVehicle(Vehicle vehicle)
    {
        Console.WriteLine("[Debug] under ParkVehicle");
        ParkingSpot? allotedSlot = _spotAssignmentStrategy.FindSpot(ParkingFloors, vehicle);
        if (allotedSlot != null)
        {
            allotedSlot.ParkedVehicle = vehicle;
            var ticket =  new Ticket(Guid.NewGuid().ToString(), vehicle, allotedSlot);
            return ticket;
        }

        return null;
    }

    public double unparkVehicle(string ticketId)
    {
        // get right ticket
        var ticket = ticketRepository.Tickets.Where(x => x.TicketId == ticketId).FirstOrDefault();
        
        var amount = _pricingStrategy.CalculatePrice(ticket);
        
        ticket.ParkingSpotRef.ParkedVehicle = null;
        
        Console.WriteLine($"Ticket {ticketId} unparked, total amount: {amount}");
        return amount;
    }
}