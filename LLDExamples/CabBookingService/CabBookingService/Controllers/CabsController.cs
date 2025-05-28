namespace CabBookingService
{
    public class CabsController
    {
        private readonly CabsManager cabsManager;
        private readonly TripsManager tripsManager;

        public CabsController(CabsManager cabsManager, TripsManager tripsManager)
        {
            this.cabsManager = cabsManager;
            this.tripsManager = tripsManager;
        }

        public string RegisterCab(string cabId, string driverName)
        {
            cabsManager.CreateCab(new Cab(cabId, driverName));
            return "OK";
        }

        public string UpdateCabLocation(string cabId, double newX, double newY)
        {
            cabsManager.UpdateCabLocation(cabId, new Location(newX, newY));
            return "OK";
        }

        public string UpdateCabAvailability(string cabId, bool newAvailability)
        {
            cabsManager.UpdateCabAvailability(cabId, newAvailability);
            return "OK";
        }

        public string EndTrip(string cabId)
        {
            var cab = cabsManager.GetCab(cabId);
            tripsManager.EndTrip(cab);
            return "OK";
        }
    }
}