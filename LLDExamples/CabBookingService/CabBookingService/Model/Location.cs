namespace CabBookingService
{
    public class Location
    {
        private double x;
        private double y;

        public Location(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Getter for X
        public double GetX()
        {
            return x;
        }

        // Getter for Y
        public double GetY()
        {
            return y;
        }

        // Method to calculate distance
        public double Distance(Location location2)
        {
            if (location2 == null) throw new ArgumentNullException(nameof(location2));
            return Math.Sqrt(Math.Pow(this.x - location2.x, 2) + Math.Pow(this.y - location2.y, 2));
        }

        public override string ToString()
        {
            return $"Location{{x={x}, y={y}}}";
        }
    }
}