namespace CabBookingService
{
    using System;

    public class Cab
    {
        private string id;
        private string driverName;

        private Trip currentTrip;
        private Location currentLocation;
        private bool isAvailable;

        public Cab(string id, string driverName)
        {
            this.id = id;
            this.driverName = driverName;
            this.isAvailable = true;
        }

        // Getter for Id
        public string GetId()
        {
            return id;
        }

        // Getter for DriverName
        public string GetDriverName()
        {
            return driverName;
        }

        // Getter and Setter for CurrentTrip
        public Trip GetCurrentTrip()
        {
            return currentTrip;
        }

        public void SetCurrentTrip(Trip trip)
        {
            currentTrip = trip;
        }

        // Getter and Setter for CurrentLocation
        public Location GetCurrentLocation()
        {
            return currentLocation;
        }

        public void SetCurrentLocation(Location location)
        {
            currentLocation = location;
        }

        // Getter and Setter for IsAvailable
        public bool GetIsAvailable()
        {
            return isAvailable;
        }

        public void SetIsAvailable(bool available)
        {
            isAvailable = available;
        }

        public override string ToString()
        {
            return $"Cab{{id='{id}', driverName='{driverName}', currentLocation={currentLocation}, isAvailable={isAvailable}}}";
        }
    }

}