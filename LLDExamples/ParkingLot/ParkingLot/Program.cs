using System;
using ParkingLot.Model;
using ParkingLot.Repositories;
using ParkingLot.Strategies;

namespace ParkingLot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Parking Lot!");
            
            // Step1: Create floors and spots
            var floor1 = new ParkingFloor(1, new List<ParkingSpot>
            {
                new SmallSpot("S1"),
                new CompactSpot("C1"),
                new LargeSpot("L1"),
                new LargeSpot("L2")
            });

            var floor2 = new ParkingFloor(2, new List<ParkingSpot>
            {
                new SmallSpot("S2"),
                new CompactSpot("C2"),
                new LargeSpot("L3")
            });
            
            // Step2: Create repository, strategy, and pricing
            var ticketRepo = new TicketRepository();
            var spotStrategy = new NearestSpotParkingStrategy();
            var pricingStrategy = new HourlyPricingStrategy();
            
            // Step3: Create parking lot
            var parkingLot = new ParkingLot(ticketRepo, spotStrategy, pricingStrategy, "City Lot", new List<ParkingFloor> { floor1, floor2 });
            
            // Step4:  Create vehicles
            var car = new Car("CAR-123");
            var bike = new Motorcylce("BIKE-777");
            var suv = new Suv("SUV-888");
            
            // Step5: Park vehicles
            var carTicket = parkingLot.ParkVehicle(car);
            if (carTicket != null)
            {
                ticketRepo.Tickets.Add(carTicket);
                Console.WriteLine($"Car parked at {carTicket.ParkingSpotRef.SpotId}, ticket {carTicket.TicketId}");
            }
            
            var bikeTicket = parkingLot.ParkVehicle(bike);
            if (bikeTicket != null)
            {
                ticketRepo.Tickets.Add(bikeTicket);
                Console.WriteLine($"Motorcycle parked at {bikeTicket.ParkingSpotRef.SpotId}, ticket {bikeTicket.TicketId}");
            }

            var suvTicket = parkingLot.ParkVehicle(suv);
            if (suvTicket != null)
            {
                ticketRepo.Tickets.Add(suvTicket);
                Console.WriteLine($"SUV parked at {suvTicket.ParkingSpotRef.SpotId}, ticket {suvTicket.TicketId}");
            }
            
            // simulate duration
            Thread.Sleep(5000);
            
            // Step6: Unpark Vehicles and get ticket amount
            // Unpark car
            carTicket.CloseTicket();
            double carAmount = parkingLot.unparkVehicle(carTicket.TicketId);

            // Unpark bike
            bikeTicket.CloseTicket();
            double bikeAmount = parkingLot.unparkVehicle(bikeTicket.TicketId);

            // Unpark SUV
            suvTicket.CloseTicket();
            double suvAmount = parkingLot.unparkVehicle(suvTicket.TicketId);
        }
    }
    
}