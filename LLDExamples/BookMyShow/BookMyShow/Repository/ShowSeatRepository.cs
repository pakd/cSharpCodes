using BookMyShow.Model;

namespace BookMyShow.Repository;

public class ShowSeatRepository
{
    public List<ShowSeat> ShowSeats { get; }

    public ShowSeatRepository()
    {
        ShowSeats = new List<ShowSeat>();
    }
    
    // get all ShowSeat for a show, required for rendering on UI.
    public List<ShowSeat> GetSeats(string showId)
    {
        return ShowSeats.Where(x => x.ShowRef.ShowId == showId).ToList();
    }

    public void AddShowSeat(Show show)
    {
        foreach (var seat in show.ScreenRef.Seats.Values)
        {
            ShowSeats.Add(new ShowSeat(show, seat, SeatState.FREE ));
        }
    }
}