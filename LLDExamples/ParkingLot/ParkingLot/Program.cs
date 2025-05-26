using System;

namespace ParkingLot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string nameOfParkingLot = "Pintosss Parking Lot";

            Address address = new Address
            {
                City = "Bangalore",
                Country = "India",
                State = "KA"
            };

            var allSlots = new Dictionary<ParkingSlotType, Dictionary<string, ParkingSlot>>();

            var compactSlot = new Dictionary<string, ParkingSlot>
            {
                { "C1", new ParkingSlot("C1", ParkingSlotType.Compact) },
                { "C2", new ParkingSlot("C2", ParkingSlotType.Compact) },
                { "C3", new ParkingSlot("C3", ParkingSlotType.Compact) }
            };
            allSlots[ParkingSlotType.Compact] = compactSlot;

            var largeSlot = new Dictionary<string, ParkingSlot>
            {
                { "L1", new ParkingSlot("L1", ParkingSlotType.Large) },
                { "L2", new ParkingSlot("L2", ParkingSlotType.Large) },
                { "L3", new ParkingSlot("L3", ParkingSlotType.Large) }
            };
            allSlots[ParkingSlotType.Large] = largeSlot;

            ParkingFloor parkingFloor = new ParkingFloor("1", allSlots);
            List<ParkingFloor> parkingFloors = new List<ParkingFloor> { parkingFloor };

            ParkingLot parkingLot = ParkingLot.GetInstance(nameOfParkingLot, address, parkingFloors);

            Vehicle vehicle = new Vehicle
            {
                VehicleCategory = VehicleCategory.Hatchback,
                VehicleNumber = "KA-01-MA-9999"
            };

            Ticket ticket = parkingLot.AssignTicket(vehicle);
            Console.WriteLine("Ticket number >> " + ticket.TicketNumber);

            // Simulate parking time
            Thread.Sleep(10000);

            double price = parkingLot.ScanAndPay(ticket);
            Console.WriteLine("Price is >> " + price);
        }
    }
}