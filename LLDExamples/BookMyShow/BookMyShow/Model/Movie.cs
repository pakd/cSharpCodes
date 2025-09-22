namespace BookMyShow.Model;

public class Movie
{
    public string MovieId { get; set; }
    public string MovieName { get; set; }
    public TimeSpan Duration { get; set; }
    

    public Movie(string id, string name, TimeSpan duration)
    {
        MovieId = id;
        MovieName = name;
        Duration = duration;
    }
}