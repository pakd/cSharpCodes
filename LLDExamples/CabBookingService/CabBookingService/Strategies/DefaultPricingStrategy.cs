namespace CabBookingService
{
    public class DefaultPricingStrategy : IPricingStrategy
    {
        public const double PER_KM_RATE = 10.0;

        public double FindPrice(Location fromPoint, Location toPoint)
        {
            if (fromPoint == null) throw new ArgumentNullException(nameof(fromPoint));
            if (toPoint == null) throw new ArgumentNullException(nameof(toPoint));

            return fromPoint.Distance(toPoint) * PER_KM_RATE;
        }
    }
}