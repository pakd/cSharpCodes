# Cab Booking Service
- Build a sab booking service to allow a rider to book a cab

## Details
- The location is represented as a (x, y) coordinate.
- Distance between two points (x1, y1) and(x2, y2) is sqrt((x1-x2)^2 + (y1-y2)^2)
- Platform has decided upon maximum distance a driver has to travel to pickup a rider.
- A cab has only 1 driver.
- Sharing of cab is not allowed between riders : no ola share, uber pool, etc
- There is a single type of cab - no uber go, uber black, etc

## Requirement
- Register a rider.
- Register a driver/cab
- Update a cab's location
- A driver can switch on/off his availability
- A rider can book a cab
- Fetch history of all rides taken by a rider.
- End the Trip

## Expectation
- Demonstrable code is first expectation. To do this, you can choose any interface you are comfortable with - CLI, WebApp, MobileApp, APIs or even simply run the code via Tests or a main method.
- Code should be extensible.
- Clean professional level code.
- Functional Completeness including good modelling.
- User Identification but not authentication.
- Backend Database is optional. However modelling should be complete.

## Entities
- Controllers - CabsController - apis for Cabs, RidersController - apis for riders
- Database and Operations - CabsManager, RiderManager, TripManager.
- Models - Cab, Location, Rider, Trip, TripStatus enum
- Strategies - PricingStrategy, CabMatchingStrategy.

## Reference
1. https://www.youtube.com/watch?v=Yn7C0x5ozx4
2. https://github.com/anomaly2104/lld-cab-booking-ola-uber-grab-lyft