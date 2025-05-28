namespace CabBookingService
{
    public interface ICabMatchingStrategy
    {
        Cab MatchCabToRider(Rider rider, List<Cab> candidateCabs, Location fromPoint, Location toPoint);
    }
}