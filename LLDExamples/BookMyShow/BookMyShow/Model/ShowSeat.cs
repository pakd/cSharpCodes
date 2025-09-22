namespace BookMyShow.Model;

public enum SeatState
{
    FREE,
    HELD,
    BOOKED
}

public class ShowSeat
{
    public Show ShowRef { get; set; }
    public Seat SeatRef { get; set; }
    public SeatState Status { get; set; }
    
    // If HELD, we keep track of which booking is holding it
    public string HoldedByBookingId { get; set; }

    public ShowSeat(Show showRef, Seat seatRef, SeatState status)
    {
        ShowRef = showRef;
        SeatRef = seatRef;
        Status = status;
    }
}