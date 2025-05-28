namespace CabBookingService
{
    public class RidersController
    {
        private readonly RidersManager ridersManager;
        private readonly TripsManager tripsManager;

        public RidersController(RidersManager ridersManager, TripsManager tripsManager)
        {
            this.ridersManager = ridersManager;
            this.tripsManager = tripsManager;
        }

        public string RegisterRider(string riderId, string riderName)
        {
            ridersManager.CreateRider(new Rider(riderId, riderName));
            return "OK";
        }

        public string Book(string riderId, double sourceX, double sourceY, double destX, double destY)
        {
            var rider = ridersManager.GetRider(riderId);
            tripsManager.CreateTrip(rider, new Location(sourceX, sourceY), new Location(destX, destY));
            return "OK";
        }

        public List<Trip> FetchHistory(string riderId)
        {
            var rider = ridersManager.GetRider(riderId);
            return tripsManager.TripHistory(rider);
        }
    }
}

