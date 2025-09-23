// See https://aka.ms/new-console-template for more information

using BookMyShow.Model;
using BookMyShow.Repository;
using BookMyShow.Service;

class Program
{
    public static void Main(string[] args)
    {
        BookingService bookingService = new BookingService();
        Console.WriteLine("Welcome to the Book My Show");
        
        // Step1: Create 2 Users
        User userAlice = new User("Alice", "Alice");
        User userBob = new User("Bob", "Bob");
        
        // Step2: Create 6 Seats, 3 normal 3 premium
        List<Seat> seats = new List<Seat>();
        for (int i = 0; i < 3; i++)
        {
            var normalSeat = new NormalSeat();
            normalSeat.SeatType = SeatType.Normal;
            normalSeat.SeatId = $"A{i}";
            normalSeat.SeatPrice = 150.0;
            seats.Add(normalSeat);
        }
        for (int i = 0; i < 3; i++)
        {
            var premiumSeat = new PremiumSeat();
            premiumSeat.SeatType = SeatType.Premium;
            premiumSeat.SeatId = $"B{i}";
            premiumSeat.SeatPrice = 450.0;
            seats.Add(premiumSeat);
        }
        
        // Step3: Create Screen now
        Dictionary<string, Seat> seatMap = new Dictionary<string, Seat>();
        foreach (var seat in seats)
        {
            seatMap[seat.SeatId] = seat;
        }

        var testScreen = new Screen("Screen1", "Imax Screen-1", seatMap);
        
        // Step4: Create theatre
        Dictionary<string, Screen> screenMap = new();
        screenMap["Screen1"] = testScreen;
        Theatre testTheatre = new Theatre("Theatre1", "Theatre1",screenMap);
        
        // Step4: Create Movie
        var testMovie = new Movie("Interstellar", "Interstellar", TimeSpan.FromMinutes(157));
        
        // Step6: Create few shows
        var showTime = DateTime.Today.AddHours(14).AddMinutes(30);
        var show1 = new Show("Show1", "Afternoon Show", testTheatre, testScreen, testMovie, showTime);
        var show2 = new Show("Show2", "Evening Show", testTheatre, testScreen, testMovie, DateTime.Today.AddHours(18));
        var show3 = new Show("Show3", "Night Show", testTheatre, testScreen, testMovie, DateTime.Today.AddHours(21));
        
        // create copies of screen seats
        bookingService.CreateSeatShowMap(show1);
        bookingService.CreateSeatShowMap(show2);
        bookingService.CreateSeatShowMap(show3);
        
        // step7: Add all of these cinema repository
        var cinemaRepository = new CinemaRepository();
        bookingService.cinemaRepository.AddMovie(testMovie);
        bookingService.cinemaRepository.AddTheatre(testTheatre);
        bookingService.cinemaRepository.AddScreen(testScreen);
        bookingService.cinemaRepository.AddShow(show1);
        bookingService.cinemaRepository.AddShow(show2);
        bookingService.cinemaRepository.AddShow(show3);
        
        // Step8: User searches for "Interstellar" show
        var availableShows = bookingService.GetShowsForMovie("Interstellar");
        Console.WriteLine($"\nAvailable shows for Interstellar:");
        foreach (var s in availableShows)
        {
            Console.WriteLine($"- {s.ShowName} at {s.StartsAt}");
        }
        
        // Step9: User selects a show (Alice selects Afternoon Show)
        var selectedShow = availableShows.First();
        
        // step10: we render all seats for that show
        Console.WriteLine($"\nSeats for {selectedShow.ShowName}:");
        foreach (var seat in selectedShow.ScreenRef.Seats.Values)
        {
            Console.WriteLine($"{seat.SeatId} ({seat.SeatType}) - {seat.SeatPrice} - {bookingService.showSeatRepository.ShowSeats.Where(x=> (x.ShowRef.ShowId == selectedShow.ShowId) && (x.SeatRef.SeatId == seat.SeatId)).FirstOrDefault().Status}");
        }
        
        // step11: user selectes seats
        var aliceSeats = selectedShow.ScreenRef.Seats.Values.Where(s => s.SeatType == SeatType.Normal).Take(2).ToList();
        Console.WriteLine("Alice Selected Seats:");
        foreach (var s in aliceSeats)
        {
            Console.WriteLine(s.SeatId);
        }
        
        // step12: user creates booking
        var booking = bookingService.CreateBooking(userAlice, selectedShow, aliceSeats, PaymentType.UPI);
        
        if (booking == null)
        {
            Console.WriteLine("Booking creation failed!");
            return;
        }
        //step13: user confirm booking
        bool confirmed = bookingService.ConfirmBooking(booking, PaymentType.UPI, "alice-upi@bank");
        if (confirmed)
        {
            Console.WriteLine("Booking successful!");
        }
        else
        {
            Console.WriteLine("Booking failed at confirmation stage.");
        }
        
        // ***** Now Bob tries same seats A1, A2 for the same show *****
        var bobSeats = selectedShow.ScreenRef.Seats.Values.Where(s => s.SeatId == "A2" || s.SeatId == "A1").ToList();
        Console.WriteLine("\nBob Selected Seats: " + string.Join(", ", bobSeats.Select(s => s.SeatId)));
        
        var bobBooking = bookingService.CreateBooking(userBob, selectedShow, bobSeats, PaymentType.Card);
        
        if (bobBooking == null)
        {
            Console.WriteLine("Bob's booking creation failed (seats already booked by Alice).");
        }
        else
        {
            Console.WriteLine("Bob booking should NOT have succeeded!");
        }

    }
}
