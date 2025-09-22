namespace BookMyShow.Model;

public class Show
{
    public string ShowId { get; set; }
    public string ShowName { get; set; }
    public Theatre TheatreRef { get; set; }
    public Screen ScreenRef { get; set; }
    public Movie MovieRef { get; set; }
    public DateTime StartsAt { get; set; }

    public Show(string showId, string showName, Theatre theatreRef, Screen screenRef, Movie movieRef, DateTime startsAt)
    {
        ShowId = showId;
        ShowName = showName;
        TheatreRef = theatreRef;
        ScreenRef = screenRef;
        MovieRef = movieRef;
        StartsAt = startsAt;
    }
}