using System.Collections.Concurrent;
using System.Reflection.Metadata;
using BookMyShow.Model;

namespace BookMyShow.Service;

public class LockingService
{
    public ConcurrentDictionary<string, string> LockedSeats { get; set; }
    private readonly object lockObject = new();

    public void LockSeat(Show Show, List<Seat> Seats, string userId)
    {
        
    }
}