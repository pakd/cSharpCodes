namespace CabBookingService
{
    public class Trip
    {
        private Rider rider;
        private Cab cab;
        private TripStatus status;
        private double price;
        private Location fromPoint;
        private Location toPoint;

        public Trip(Rider rider, Cab cab, double price, Location fromPoint, Location toPoint)
        {
            this.rider = rider ?? throw new ArgumentNullException(nameof(rider));
            this.cab = cab ?? throw new ArgumentNullException(nameof(cab));
            this.price = price;
            this.fromPoint = fromPoint ?? throw new ArgumentNullException(nameof(fromPoint));
            this.toPoint = toPoint ?? throw new ArgumentNullException(nameof(toPoint));
            this.status = TripStatus.IN_PROGRESS;
        }

        public void EndTrip()
        {
            this.status = TripStatus.FINISHED;
        }

        public override string ToString()
        {
            return $"Trip{{rider={rider}, cab={cab}, status={status}, price={price}, fromPoint={fromPoint}, toPoint={toPoint}}}";
        }
    }

}