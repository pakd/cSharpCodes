using BookMyShow.Model;
using BookMyShow.Payment;
using BookMyShow.Repository;

namespace BookMyShow.Service;

public class BookingService
{
    public LockingService lockingService { get; set; }
    public BookingRepository bookingRepository { get; set; }
    public ShowSeatRepository showSeatRepository { get; set; }
    public CinemaRepository cinemaRepository { get; set; }
    private readonly object _lock;

    public BookingService()
    {
        lockingService = new LockingService();
        bookingRepository = new BookingRepository();
        showSeatRepository = new ShowSeatRepository();
        cinemaRepository = new CinemaRepository();
        _lock = new object();
    }
    
    // ideally, it should have been in a different class.
    public List<Show> GetShowsForMovie(string movieName)
    {
        // Get a list of all shows using movieId
        return cinemaRepository.Shows.Where(x => x.MovieRef.MovieName == movieName).ToList();
    }
    
    public void CreateSeatShowMap(Show show)
    {
        showSeatRepository.AddShowSeat(show);
    }
    
    // Step 1: Create Booking (check seats + lock + save booking)
    public Booking? CreateBooking(User user, Show show, List<Seat> seats, PaymentType paymentType)
    {
        lock (_lock)
        {
            double totalAmount = 0;
            var lockedSeats = new List<Seat>();
        
            // 1. Get ShowSeats for the selected show.
            List<ShowSeat> selectedShowSeats = showSeatRepository.GetSeats(show.ShowId);
        
            // 2. make sure every seat in userSeats is free.
            bool evenIfOneSeatIsOccupied = false;
            foreach (var seat in selectedShowSeats)
            {
                foreach (var userSeats in seats)
                {
                    if (seat.SeatRef.SeatId == userSeats.SeatId)
                    {
                        if (seat.Status != SeatState.FREE)
                        {
                            evenIfOneSeatIsOccupied = true;
                        }
                    }
                }
            }

            if (evenIfOneSeatIsOccupied)
            {
                Console.WriteLine("Seats are not available now, Try Again Later!");
                return null;
            }
        
            // 3. Try to acquire lock on all seats one by one
            foreach (var seat in seats)
            {
                // Try acquiring lock for this seat
                if (!lockingService.AcquireLock(show, seat, user.UserId))
                {
                    Console.WriteLine($"Seat {seat.SeatId} is already locked! Rolling back...");

                    // Rollback previously locked seats
                    foreach (var s in lockedSeats)
                    {
                        lockingService.ReleaseLock(show, s);
                        var ss = selectedShowSeats.First(x => x.SeatRef.SeatId == s.SeatId);
                        ss.Status = SeatState.FREE;
                    }

                    return null;
                }
                
                // Mark as HELD after lock
                var showSeat = selectedShowSeats.First(s => s.SeatRef.SeatId == seat.SeatId);
                showSeat.Status = SeatState.HELD;

                totalAmount += seat.SeatPrice;
            }

            // 4. Create booking with "Created" status
            var booking = new Booking(Guid.NewGuid().ToString(), show, user, seats, totalAmount, paymentType);
            bookingRepository.SaveBooking(booking);

            Console.WriteLine($"Booking {booking.BookingId} created with status {booking.Status}");
            return booking;
        }
        
    }

    public bool ConfirmBooking(Booking booking, PaymentType paymentType, string paymentDetails)
    {
        if (booking.Status != BookingStatus.Created)
        {
            return false;
        }
        
        // 1. get payment strategy for user
        var paymentStrategy = PaymentFactory.GetPaymentStrategy(paymentType, paymentDetails);
        
        // 2. do payment
        bool paymentSuccess = paymentStrategy.Pay(booking.TotalAmount, booking.UserRef.UserId);
        if (!paymentSuccess)
        {
            Console.WriteLine("Payment failed!");
            return false;
        }
        
        // 3. Update booking now
        booking.Status = BookingStatus.Paid;
        
        
        // 4. Update system properties
        // update showseat status
        // remove locks
        foreach (var seat in booking.Seats)
        {
            // we have to update for this show seat only
            var actualSeat = showSeatRepository.ShowSeats.Where(x => (x.ShowRef.ShowId == booking.ShowRef.ShowId) && (x.SeatRef.SeatId == seat.SeatId)).FirstOrDefault();
            if (actualSeat == null)
            {
                Console.WriteLine("Seat not found!");
            }
            actualSeat.Status = SeatState.BOOKED;
            lockingService.ReleaseLock(booking.ShowRef, seat);
        }

        Console.WriteLine($"Booking {booking.BookingId} confirmed!");
        return true;
    }
}