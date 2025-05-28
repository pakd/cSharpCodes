namespace CabBookingService
{
    public class TripsManager
    {
        public static readonly double MAX_ALLOWED_TRIP_MATCHING_DISTANCE = 10.0;

        private Dictionary<string, List<Trip>> trips = new Dictionary<string, List<Trip>>();

        private CabsManager cabsManager;
        private RidersManager ridersManager;
        private ICabMatchingStrategy cabMatchingStrategy;
        private IPricingStrategy pricingStrategy;

        public TripsManager(
            CabsManager cabsManager,
            RidersManager ridersManager,
            ICabMatchingStrategy cabMatchingStrategy,
            IPricingStrategy pricingStrategy)
        {
            this.cabsManager = cabsManager;
            this.ridersManager = ridersManager;
            this.cabMatchingStrategy = cabMatchingStrategy;
            this.pricingStrategy = pricingStrategy;
        }

        public void CreateTrip(Rider rider, Location fromPoint, Location toPoint)
        {
            if (rider == null) throw new ArgumentNullException(nameof(rider));
            if (fromPoint == null) throw new ArgumentNullException(nameof(fromPoint));
            if (toPoint == null) throw new ArgumentNullException(nameof(toPoint));

            var closeByCabs = cabsManager.GetCabs(fromPoint, MAX_ALLOWED_TRIP_MATCHING_DISTANCE);
            var closeByAvailableCabs = closeByCabs
                .Where(cab => cab.GetCurrentTrip() == null)
                .ToList();

            var selectedCab = cabMatchingStrategy.MatchCabToRider(rider, closeByAvailableCabs, fromPoint, toPoint);

            if (selectedCab == null)
            {
                throw new Exception("No cabs available.");
            }

            double price = pricingStrategy.FindPrice(fromPoint, toPoint);
            Trip newTrip = new Trip(rider, selectedCab, price, fromPoint, toPoint);

            string riderId = rider.GetId();
            if (!trips.ContainsKey(riderId))
            {
                trips[riderId] = new List<Trip>();
            }

            trips[riderId].Add(newTrip);
            selectedCab.SetCurrentTrip(newTrip);
        }

        public List<Trip> TripHistory(Rider rider)
        {
            if (rider == null) throw new ArgumentNullException(nameof(rider));
            string riderId = rider.GetId();

            return trips.ContainsKey(riderId) ? trips[riderId] : new List<Trip>();
        }

        public void EndTrip(Cab cab)
        {
            if (cab == null) throw new ArgumentNullException(nameof(cab));
            Trip currentTrip = cab.GetCurrentTrip();

            if (currentTrip == null)
            {
                throw new Exception("No active trip found for the cab.");
            }

            currentTrip.EndTrip();
            cab.SetCurrentTrip(null);
        }
    }
}