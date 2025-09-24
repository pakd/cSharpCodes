using ParkingLot.Model;

namespace ParkingLot.Strategies;

public class HourlyPricingStrategy : IPricingStrategy
{
    private static readonly Dictionary<SpotType, double> _ratesPerHour = new Dictionary<SpotType, double>
    {
        { SpotType.SMALL, 20 },
        { SpotType.COMPACT, 40 },
        { SpotType.LARGE, 60 }
    };

    public double CalculatePrice(Ticket ticket)
    {
        if (ticket.ExitTime == null)
            throw new InvalidOperationException("Cannot calculate price: Ticket has no exit time.");

        double totalDurationHours = Math.Ceiling((ticket.ExitTime - ticket.EntryTime).TotalHours);
        double ratePerHour = _ratesPerHour[ticket.ParkingSpotRef.SpotType];

        return totalDurationHours * ratePerHour;
    }
}
