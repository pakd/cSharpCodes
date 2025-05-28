namespace CabBookingService
{
    public class DefaultCabMatchingStrategy : ICabMatchingStrategy
    {
        public Cab MatchCabToRider(Rider rider, List<Cab> candidateCabs, Location fromPoint, Location toPoint)
        {
            if (candidateCabs == null) throw new ArgumentNullException(nameof(candidateCabs));
            if (rider == null) throw new ArgumentNullException(nameof(rider));
            if (fromPoint == null) throw new ArgumentNullException(nameof(fromPoint));
            if (toPoint == null) throw new ArgumentNullException(nameof(toPoint));

            if (candidateCabs.Count == 0)
            {
                return null;
            }

            return candidateCabs[0];
        }
    }
}