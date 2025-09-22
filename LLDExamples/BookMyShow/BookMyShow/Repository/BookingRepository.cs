using BookMyShow.Model;

namespace BookMyShow.Repository;

public class BookingRepository
{
    private Dictionary<string, Booking> _bookings;

    public BookingRepository()
    {
        _bookings = new Dictionary<string, Booking>();
    }

    public Booking? GetBooking(string id)
    {
        return _bookings.ContainsKey(id) ? _bookings[id] : null;
    }

    public void SaveBooking(Booking booking)
    {
        _bookings[booking.BookingId] = booking;
    }
}