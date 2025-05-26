# Parking Lot

## Requirement
- Multilevel parking lot
- multiple categories of parking space
- multiple entry and exit
- should not allow more vehicles than allocated space for each category
- charges should be hourly basis
- Display available number of parking slots for each category at entry itself

## Entities
- Model
    - Address - just address of the parking slot
    - ParkingSlotType - enum: TwoWheeler, Compact, Medium, Large
    - ParkingSlotPricing - method to get prices for different ParkingSlotType
    - Vehicle - vehicle details like vehicle number and vehicle category (we can use camera based detection)
    - VehicleCategory - enum: TwoWheeler, Hatchback, Sedan, SUV, Bus
- ParkingSlot - class to represent parking slot, holds vehicle as well, method to add and remove vehicle
- ParkingFloor - holds all parking slots on a floor, method to get relevant slot, and park vehicle on the slot
- ParkingLot - Main class , have multiple parking floors, AssignTicket after finding the slot by brute forcing on the floors, ScanAndPay: price by scanning  ticket.

## Reference
1. https://www.youtube.com/watch?v=Sh3HeOMRoTQ