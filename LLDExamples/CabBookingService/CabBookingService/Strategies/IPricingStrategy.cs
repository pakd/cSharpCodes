namespace CabBookingService
{
    public interface IPricingStrategy
    {
        double FindPrice(Location fromPoint, Location toPoint);
    }
}