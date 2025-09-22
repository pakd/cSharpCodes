namespace BookMyShow.Model;

public class Show
{
    public string ShowId { get; set; }
    public string ShowName { get; set; }
    public string TheatreId { get; set; }
    public string ScreenId { get; set; }
    public string MovieId { get; set; }
    public DateTime StartsAt { get; set; }

    public Show(string showId, string showName, string theatre, string screen, string movie, DateTime startsAt)
    {
        ShowId = showId;
        ShowName = showName;
        theatre = theatre;
        screen = screen;
        movie = movie;
        StartsAt = startsAt;
    }
}