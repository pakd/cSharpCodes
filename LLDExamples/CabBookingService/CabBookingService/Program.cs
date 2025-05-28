using System;
using System.Collections.Generic;

namespace CabBookingService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cabsManager = new CabsManager();
            var ridersManager = new RidersManager();

            ICabMatchingStrategy cabMatchingStrategy = new DefaultCabMatchingStrategy();
            IPricingStrategy pricingStrategy = new DefaultPricingStrategy();

            var tripsManager = new TripsManager(cabsManager, ridersManager, cabMatchingStrategy, pricingStrategy);

            var cabsController = new CabsController(cabsManager, tripsManager);
            var ridersController = new RidersController(ridersManager, tripsManager);

            try
            {
                string r1 = "r1";
                ridersController.RegisterRider(r1, "ud");
                string r2 = "r2";
                ridersController.RegisterRider(r2, "du");
                string r3 = "r3";
                ridersController.RegisterRider(r3, "rider3");
                string r4 = "r4";
                ridersController.RegisterRider(r4, "rider4");

                string c1 = "c1";
                cabsController.RegisterCab(c1, "driver1");
                string c2 = "c2";
                cabsController.RegisterCab(c2, "driver2");
                string c3 = "c3";
                cabsController.RegisterCab(c3, "driver3");
                string c4 = "c4";
                cabsController.RegisterCab(c4, "driver4");
                string c5 = "c5";
                cabsController.RegisterCab(c5, "driver5");

                cabsController.UpdateCabLocation(c1, 1.0, 1.0);
                cabsController.UpdateCabLocation(c2, 2.0, 2.0); // na
                cabsController.UpdateCabLocation(c3, 100.0, 100.0);
                cabsController.UpdateCabLocation(c4, 110.0, 110.0); // na
                cabsController.UpdateCabLocation(c5, 4.0, 4.0);

                cabsController.UpdateCabAvailability(c2, false);
                cabsController.UpdateCabAvailability(c4, false);

                ridersController.Book(r1, 0.0, 0.0, 500.0, 500.0);
                ridersController.Book(r2, 0.0, 0.0, 500.0, 500.0);

                Console.WriteLine("\n### Printing current trips for r1 and r2");
                PrintTrips(ridersController.FetchHistory(r1));
                PrintTrips(ridersController.FetchHistory(r2));

                cabsController.UpdateCabLocation(c5, 50.0, 50.0);

                Console.WriteLine("\n### Printing current trips for r1 and r2");
                PrintTrips(ridersController.FetchHistory(r1));
                PrintTrips(ridersController.FetchHistory(r2));

                cabsController.EndTrip(c5);

                Console.WriteLine("\n### Printing current trips for r1 and r2");
                PrintTrips(ridersController.FetchHistory(r1));
                PrintTrips(ridersController.FetchHistory(r2));

                // Test exceptions manually using try/catch
                try
                {
                    ridersController.Book(r3, 0.0, 0.0, 500.0, 500.0);
                    Console.WriteLine("ERROR: Expected NoCabsAvailableException not thrown for r3 booking");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Caught expected NoCabsAvailableException for r3 booking", ex.Message);
                }

                ridersController.Book(r4, 48.0, 48.0, 500.0, 500.0);
                Console.WriteLine("\n### Printing current trips for r1, r2 and r4");
                PrintTrips(ridersController.FetchHistory(r1));
                PrintTrips(ridersController.FetchHistory(r2));
                PrintTrips(ridersController.FetchHistory(r4));

                try
                {
                    ridersController.Book("abcd", 0.0, 0.0, 500.0, 500.0);
                    Console.WriteLine("ERROR: Expected RiderNotFoundException not thrown for unknown rider booking");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Caught expected RiderNotFoundException for unknown rider booking", ex.Message);
                }

                try
                {
                    ridersController.RegisterRider("r1", "shjgf");
                    Console.WriteLine(
                        "ERROR: Expected RiderAlreadyExistsException not thrown for duplicate rider registration");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Caught expected RiderAlreadyExistsException for duplicate rider registration", ex.Message);
                }

                try
                {
                    cabsController.RegisterCab("c1", "skjhsfkj");
                    Console.WriteLine(
                        "ERROR: Expected CabAlreadyExistsException not thrown for duplicate cab registration");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Caught expected CabAlreadyExistsException for duplicate cab registration", ex.Message);
                }

                try
                {
                    cabsController.UpdateCabLocation("shss", 110.0, 110.0);
                    Console.WriteLine(
                        "ERROR: Expected CabNotFoundException not thrown for invalid cab location update");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Caught expected CabNotFoundException for invalid cab location update",ex.Message);
                }

                try
                {
                    cabsController.UpdateCabAvailability("shss", false);
                    Console.WriteLine(
                        "ERROR: Expected CabNotFoundException not thrown for invalid cab availability update");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Caught expected CabNotFoundException for invalid cab availability update");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected exception: " + ex.Message, ex.StackTrace);
            }
        }

        private static void PrintTrips(List<Trip> trips)
        {
            if (trips == null || trips.Count == 0)
            {
                Console.WriteLine("No trips found.");
                return;
            }

            foreach (var trip in trips)
            {
                Console.WriteLine(trip);
            }
        }
    }
}