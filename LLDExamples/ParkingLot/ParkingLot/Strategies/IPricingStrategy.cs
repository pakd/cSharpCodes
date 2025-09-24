using ParkingLot.Model;

namespace ParkingLot.Strategies;

public interface IPricingStrategy
{
    double CalculatePrice(Ticket ticket);
}