namespace BookMyShow.Model;

public enum SeatState
{
    FREE,
    HELD,
    BOOKED
}

public class ShowSeat
{
    public string ShowId { get; set; }
    public string seatId { get; set; }
    public SeatState Status { get; set; }
    
    // If HELD, we keep track of which booking is holding it
    public string HoldedByBookingId { get; set; }

    public ShowSeat(string showId, string seatId, SeatState status)
    {
        ShowId = showId;
        this.seatId = seatId;
        Status = status;
    }
}