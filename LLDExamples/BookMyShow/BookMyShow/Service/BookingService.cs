using BookMyShow.Model;
using BookMyShow.Repository;

namespace BookMyShow.Service;

public class BookingService
{
    private LockingService lockingService;
    private BookingRepository bookingRepository;
    private ShowSeatRepository showSeatRepository;
    private CinemaRepository cinemaRepository;

    public BookingService()
    {
        lockingService = new LockingService();
        bookingRepository = new BookingRepository();
        showSeatRepository = new ShowSeatRepository();
        cinemaRepository = new CinemaRepository();
    }
    
    // ideally, it should have been in a different class.
    public List<Show> GetShowsForMovie(string movieName)
    {
        // Get MovieObject using movieName
        Movie selectedMovie = cinemaRepository.Movies.Values.ToList().Where(x => x.MovieName == movieName).FirstOrDefault();
        
        // Get a list of all shows using movieId
        List<Show> filteredShows = cinemaRepository.Shows.Values.ToList().Where(x => x.MovieRef.MovieId == selectedMovie.MovieId).ToList();
            
        return filteredShows;
    }
    
    public void CreateSeatShowMap(Show show)
    {
        // get screen
        Screen screen = cinemaRepository.Screens[show.ScreenRef.ScreenId];
        
        foreach(var seat in screen.Seats.Values)
        {
            ShowSeat showSeat = new ShowSeat(show, seat, SeatState.FREE);
        }
    }
    
    // Step 1: Create Booking (check seats + lock + save booking)
    public Booking? CreateBooking(User user, Show show, List<Seat> seats, PaymentType paymentType)
    {
        decimal totalAmount = 0;

        List<ShowSeat> selectedShowSeats = showSeatRepository.GetSeats(show.ShowId);
        foreach (var seat in selectedShowSeats)
        {
            if(sea)
        }
        
        // Check seat availability
        foreach (var seat in seats)
        {
            // Quickly check if ShowSeat is free for these seats
            

            // Try acquiring lock for this seat
            if (!_lockService.AcquireLock(showId, seatId, userId))
            {
                Console.WriteLine($"Seat {seatId} is already locked!");
                return null;
            }

            totalAmount += seat.Amount;
        }

        // Create booking with "Created" status
        var booking = new Booking(
            id: new Random().Next(1000, 9999),
            showId: showId,
            userId: userId,
            seatIds: seatIds,
            amount: totalAmount,
            paymentType: paymentType
        );

        _bookingRepo.SaveBooking(booking);

        Console.WriteLine($"Booking {booking.Id} created with status {booking.Status}");
        return booking;
    }
}