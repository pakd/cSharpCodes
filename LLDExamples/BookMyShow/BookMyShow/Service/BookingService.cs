using BookMyShow.Model;
using BookMyShow.Repository;

namespace BookMyShow.Service;

public class BookingService
{
    public List<Show> GetShows(string movieName)
    {
        // Get MovieObject using movieName
        Movie selectedMovie = CinemaRepository.GetInstance().Movies.Values.ToList().Where(x => x.MovieName == movieName).FirstOrDefault();
        
        // Get list of all shows using movieId
        List<Show> filteredShows = CinemaRepository.GetInstance().Shows.Values.ToList().Where(x => x.MovieId == selectedMovie.MovieId).ToList();
            
        return filteredShows;
    }
    
    public void CreateSeatShowMap(Show show)
    {
        // get screen
        Screen screen = CinemaRepository.GetInstance().Screens[show.ScreenId];
        
        foreach(var seat in screen.Seats.Values)
        {
            ShowSeat showSeat = new ShowSeat(show.ShowId, seat.SeatId, SeatState.FREE);
        }
    }
}