namespace CabBookingService
{
    public class Rider
    {
        private string id;
        private string name;

        public Rider(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        // Getter for Id
        public string GetId()
        {
            return id;
        }

        // Getter for Name
        public string GetName()
        {
            return name;
        }

        public override string ToString()
        {
            return $"Rider{{id='{id}', name='{name}'}}";
        }
    }
}