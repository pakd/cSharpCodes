namespace BookMyShow.Model;

public enum BookingStatus
{
    Created,
    Paid
}

public enum PaymentType
{
    UPI,
    Card
}

public class Booking
{
    public string BookingId { get; set; }
    public Show ShowRef { get; set; }
    public User UserRef { get; set; }
    public List<Seat> Seats { get; set; }
    public BookingStatus Status { get; set; }
    public PaymentType paymentType { get; set; }

    public Booking(string bookingId, Show showRef, User userRef, List<Seat> seats, PaymentType paymentType)
    {
        BookingId = bookingId;
        ShowRef = showRef;
        UserRef = userRef;
        Seats = seats;
        Status = BookingStatus.Created;
        this.paymentType = paymentType;
    }
}