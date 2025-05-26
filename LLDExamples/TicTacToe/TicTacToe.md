# Tic Tac Toe

## Entities
- Board: should contain grid, all the methods to check valid move, winner, etc.
- Player: player info and marker
- Game: take 2 players and Board and start game, Start method contains player turns, take their input and check winner on every move.

Note:-
- Win check method is currently brute force that can be optimzied using map for rows and columns and diagonals and maintaining count for markers.