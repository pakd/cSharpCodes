using BookMyShow.Model;

namespace BookMyShow.Repository
{
    public class CinemaRepository
    {
        // Lists instead of dictionaries
        public List<Theatre> Theatres { get; private set; }
        public List<Screen> Screens { get; private set; }
        public List<Movie> Movies { get; private set; }
        public List<Show> Shows { get; private set; }

        public CinemaRepository()
        {
            Theatres = new List<Theatre>();
            Screens = new List<Screen>();
            Movies = new List<Movie>();
            Shows = new List<Show>();
        }

        // Helper methods
        public void AddTheatre(Theatre theatre)
        {
            if (!Theatres.Any(t => t.TheatreId == theatre.TheatreId))
            {
                Theatres.Add(theatre);
            }
        }

        public void AddMovie(Movie movie)
        {
            if (!Movies.Any(m => m.MovieId == movie.MovieId))
            {
                Movies.Add(movie);
            }
        }

        public void AddShow(Show show)
        {
            if (!Shows.Any(s => s.ShowId == show.ShowId))
            {
                Shows.Add(show);
                Console.WriteLine($"Show: {show.ShowId} is added sucessfully");
            }
        }

        public void AddScreen(Screen screen)
        {
            if (!Screens.Any(s => s.ScreenId == screen.ScreenId))
            {
                Screens.Add(screen);
            }
        }

        // Lookup methods
        public Movie? GetMovieById(string movieId) => Movies.FirstOrDefault(m => m.MovieId == movieId);
        public Show? GetShowById(string showId) => Shows.FirstOrDefault(s => s.ShowId == showId);
        public Screen? GetScreenById(string screenId) => Screens.FirstOrDefault(s => s.ScreenId == screenId);
        public Theatre? GetTheatreById(string theatreId) => Theatres.FirstOrDefault(t => t.TheatreId == theatreId);
    }
}