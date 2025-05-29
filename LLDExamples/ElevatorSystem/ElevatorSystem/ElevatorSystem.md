# Elevator System
Elevators are an essential component of many buildings, especially those with multiple floors or high-rise structures, where stairs may not be a practical option. The objective of an elevator system is to provide an alternative means of vertical transportation that is convenient, accessible, and safe for all building occupants.

## Requirement
- There can be multiple floors
- There can be more than one elevator
- Elevators can be added or removed(for maintenance) as needed.
- Two types of requests to be considered-
    - Person on the floor pressing the UP/DOWN button to call the elevator
    - Person in the elevator pressing the floor number button to reach a destination
- The algorithm for calling the elevator should be dynamic.
- The functional algorithm for the elevator should also be dynamic

## Entities
- ElevatorSystem
- ElevatorCar
- ElevatorController
- Floor
- Button- InternalButton, ExternalButton
- Direction- UP, DOWN, NONE
- Display
- Door
- Dispatcher- InternalDispatcher, ExternalDispatcher
- ElevatorSelectionStrategy- OddEvenStrategy, ZoneStrategy
- ElevatorControlStrategy- FirstComeFirstServe, ShortestSeekTime, ScanAlgorithm, LookAlgorithm

## Use-Cases (for PM only - can ignore)
- call the elevator
- move/stop the elevator
- open/close the door
- indicating the elevator direction
- indication current floor position
- triggering emergency brakes
- triggering emergency calls  

## Reference
1. https://www.youtube.com/watch?v=siqiJAJWUVg
2. https://swatijha.hashnode.dev/elevator-system-low-level-design