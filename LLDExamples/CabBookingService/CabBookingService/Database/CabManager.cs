namespace CabBookingService
{
    public class CabsManager
    {
        private Dictionary<string, Cab> cabs = new Dictionary<string, Cab>();

        public void CreateCab(Cab newCab)
        {
            if (newCab == null) throw new ArgumentNullException(nameof(newCab));
            if (cabs.ContainsKey(newCab.GetId()))
            {
                throw new Exception($"Cab with ID '{newCab.GetId()}' already exists.");
            }

            cabs[newCab.GetId()] = newCab;
        }

        public Cab GetCab(string cabId)
        {
            if (string.IsNullOrEmpty(cabId)) throw new ArgumentNullException(nameof(cabId));
            if (!cabs.ContainsKey(cabId))
            {
                throw new Exception($"Cab with ID '{cabId}' not found.");
            }

            return cabs[cabId];
        }

        public void UpdateCabLocation(string cabId, Location newLocation)
        {
            if (string.IsNullOrEmpty(cabId)) throw new ArgumentNullException(nameof(cabId));
            if (newLocation == null) throw new ArgumentNullException(nameof(newLocation));
            if (!cabs.ContainsKey(cabId))
            {
                throw new Exception($"Cab with ID '{cabId}' not found.");
            }

            cabs[cabId].SetCurrentLocation(newLocation);
        }

        public void UpdateCabAvailability(string cabId, bool newAvailability)
        {
            if (string.IsNullOrEmpty(cabId)) throw new ArgumentNullException(nameof(cabId));
            if (!cabs.ContainsKey(cabId))
            {
                throw new Exception($"Cab with ID '{cabId}' not found.");
            }

            cabs[cabId].SetIsAvailable(newAvailability);
        }

        public List<Cab> GetCabs(Location fromPoint, double distance)
        {
            if (fromPoint == null) throw new ArgumentNullException(nameof(fromPoint));

            List<Cab> result = new List<Cab>();
            foreach (var cab in cabs.Values)
            {
                if (cab.GetIsAvailable() && cab.GetCurrentLocation().Distance(fromPoint) <= distance)
                {
                    result.Add(cab);
                }
            }
            return result;
        }
    }
}