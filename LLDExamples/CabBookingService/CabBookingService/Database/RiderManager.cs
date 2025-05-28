namespace CabBookingService
{
    public class RidersManager
    {
        private Dictionary<string, Rider> riders = new Dictionary<string, Rider>();

        public void CreateRider(Rider newRider)
        {
            if (newRider == null) throw new ArgumentNullException(nameof(newRider));
            if (riders.ContainsKey(newRider.GetId()))
            {
                throw new Exception($"Rider with ID '{newRider.GetId()}' already exists.");
            }

            riders[newRider.GetId()] = newRider;
        }

        public Rider GetRider(string riderId)
        {
            if (string.IsNullOrEmpty(riderId)) throw new ArgumentNullException(nameof(riderId));
            if (!riders.ContainsKey(riderId))
            {
                throw new Exception($"Rider with ID '{riderId}' not found.");
            }

            return riders[riderId];
        }
    }
}

