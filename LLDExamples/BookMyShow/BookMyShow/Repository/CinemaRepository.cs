using BookMyShow.Model;

namespace BookMyShow.Repository;

public class CinemaRepository
{
    private static CinemaRepository _cinemaRepositoryInstance;
    private static readonly object _lock = new();
    
    
    // Dictionaries for storing objects
    public Dictionary<string, Theatre> Theatres { get; private set; }
    public Dictionary<string, Screen> Screens { get; private set; }
    public Dictionary<string, Movie> Movies { get; private set; }
    public Dictionary<string, Show> Shows { get; private set; }

    private CinemaRepository()
    {
        Theatres = new Dictionary<string, Theatre>();
        Screens = new Dictionary<string, Screen>();
        Movies = new Dictionary<string, Movie>();
        Shows = new Dictionary<string, Show>();
    }

    public static CinemaRepository GetInstance()
    {
        lock (_lock)
        {
            if (_cinemaRepositoryInstance == null)
            {
                _cinemaRepositoryInstance = new CinemaRepository();
            }
            return _cinemaRepositoryInstance;
        }
        
    }
    
    // Example helper methods
    public void AddTheatre(Theatre theatre)
    {
        if (!Theatres.ContainsKey(theatre.TheatreId))
        {
            Theatres[theatre.TheatreId] = theatre;
        }
    }

    public void AddMovie(Movie movie)
    {
        if (!Movies.ContainsKey(movie.MovieId))
        {
            Movies[movie.MovieId] = movie;
        }
    }

    public void AddShow(Show show)
    {
        if (!Shows.ContainsKey(show.ShowId))
        {
            Shows[show.ShowId] = show;
        }
    }
    
    public void AddScreen(Screen screen)
    {
        if (!Screens.ContainsKey(screen.ScreenId))
        {
            Screens[screen.ScreenId] = screen;
        }
    }
}