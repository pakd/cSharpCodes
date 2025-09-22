namespace BookMyShow.Model;

public class Theatre
{
    public string TheatreId { get; set; }
    public string TheatreName { get; set; }
    public Dictionary<string, Screen> Screens { get; set; }

    public Theatre(string theatreId, string theatreName, Dictionary<string, Screen> screens)
    {
        TheatreId = theatreId;
        TheatreName = theatreName;
        Screens = screens;
    }
}