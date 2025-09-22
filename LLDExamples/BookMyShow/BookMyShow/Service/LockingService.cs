using System.Collections.Concurrent;
using System.Reflection.Metadata;
using BookMyShow.Model;

namespace BookMyShow.Service;

public class LockingService
{
    public ConcurrentDictionary<string, string> LockedSeats { get; set; }

    public LockingService()
    {
        this.LockedSeats = new ConcurrentDictionary<string, string>();
    }
    public bool AcquireLock(Show show, Seat seat, string userId)
    {
        string key = $"{show.ShowId}_{seat.SeatId}";
        if (!LockedSeats.ContainsKey(key))
        {
            LockedSeats[key] = userId;

            _ = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(30));
                ReleaseLock(show, seat);
            });
            return true;
        }

        return false;
    }

    public void ReleaseLock(Show Show, Seat seat)
    {
        string key = $"{Show.ShowId}_{seat.SeatId}";
        if (LockedSeats.ContainsKey(key))
        {
            LockedSeats.Remove(key, out _);
        }
    }
}