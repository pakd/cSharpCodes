namespace BookMyShow.Model;

public class Movie
{
    public string MovieId { get; set; }
    public string MovieName { get; set; }
    public int DurationInMinutes { get; set; }

    public Movie(string movieId, string movieName, int durationInMinutes)
    {
        MovieId = movieId;
        MovieName = movieName;
        this.DurationInMinutes = durationInMinutes;
    }
}