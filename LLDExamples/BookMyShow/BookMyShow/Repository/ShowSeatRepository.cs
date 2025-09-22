using BookMyShow.Model;

namespace BookMyShow.Repository;

public class ShowSeatRepository
{
    private static ShowSeatRepository _showSeatRepository;
    private static readonly object _lock = new();
    
    
    public List<ShowSeat> ShowSeats { get; }

    private ShowSeatRepository()
    {
        ShowSeats = new List<ShowSeat>();
    }

    public static ShowSeatRepository GetInstance()
    {
        lock (_lock)
        {
            if (_showSeatRepository == null)
            {
                _showSeatRepository = new ShowSeatRepository();
            }
            return _showSeatRepository;
        }
        
    }
}