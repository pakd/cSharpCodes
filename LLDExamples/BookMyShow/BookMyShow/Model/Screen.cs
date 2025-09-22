namespace BookMyShow.Model;

public class Screen
{
    public string ScreenId { get; set; }
    public string ScreenName { get; set; }
    public Dictionary<string, Seat> Seats { get; set; }

    public Screen(string id, string name, Dictionary<string, Seat> seats)
    {
        this.ScreenId = id;
        this.ScreenName = name;
        this.Seats = seats;
    }
}