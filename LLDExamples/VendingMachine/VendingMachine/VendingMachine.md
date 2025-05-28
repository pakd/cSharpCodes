# Vending Machine
- Vending machine is example of state design pattern

## Requirements
- Insert Cash Button -> Insert Cash -> Select Product Button -> Enter Number/Select Product -> [Optional] CancelButton -> Coin Change Tray -> Dispense Tray
- Vending Machine has Inventory of multiple items. People can pay and select the item(s).

## Entities
- VendingMachine - main base class which has Inventory, list of Coin and State.
- Inventory - made of up ItemShelf, ItemShelf has Item and cost
- Item - actual item, ItemType - type of item
- IState - base State interface, IdleState, HasMoneyState, SelectionState $ DispenseState are implementation of IState


## Reference:
1. https://www.youtube.com/watch?v=wOXs5Z_z0Ew