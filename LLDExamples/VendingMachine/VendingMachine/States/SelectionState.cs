namespace VendingMachine
{
    public class SelectionState : IState
    {
        public SelectionState()
        {
            Console.WriteLine("Currently Vending machine is in SelectionState");
        }

        public void ClickOnInsertCoinButton(VendingMachine machine)
        {
            throw new Exception("You cannot click on insert coin button in Selection state");
        }

        public void ClickOnStartProductSelectionButton(VendingMachine machine)
        {
            // No action needed
        }

        public void InsertCoin(VendingMachine machine, Coin coin)
        {
            throw new Exception("You cannot insert coin in Selection state");
        }

        public void ChooseProduct(VendingMachine machine, int codeNumber)
        {
            // 1. Get item
            Item item = machine.GetInventory().GetItem(codeNumber);

            // 2. Total amount paid by user
            int paidByUser = 0;
            foreach (var coin in machine.GetCoinList())
            {
                paidByUser += (int)coin;
            }

            // 3. Compare product price and amount paid
            if (paidByUser < item.Price)
            {
                Console.WriteLine($"Insufficient amount. Product price: {item.Price}, Paid: {paidByUser}");
                RefundFullMoney(machine);
                throw new Exception("Insufficient amount");
            }
            else
            {
                if (paidByUser > item.Price)
                {
                    GetChange(paidByUser - item.Price);
                }

                machine.SetVendingMachineState(new DispenseState(machine, codeNumber));
            }
        }

        public int GetChange(int returnExtraMoney)
        {
            Console.WriteLine("Returned the change in the Coin Dispense Tray: " + returnExtraMoney);
            return returnExtraMoney;
        }

        public List<Coin> RefundFullMoney(VendingMachine machine)
        {
            Console.WriteLine("Returned the full amount back in the Coin Dispense Tray");
            machine.SetVendingMachineState(new IdleState(machine));
            return machine.GetCoinList();
        }

        public Item DispenseProduct(VendingMachine machine, int codeNumber)
        {
            throw new Exception("Product cannot be dispensed in Selection state");
        }

        public void UpdateInventory(VendingMachine machine, Item item, int codeNumber)
        {
            throw new Exception("Inventory cannot be updated in Selection state");
        }
    }
}