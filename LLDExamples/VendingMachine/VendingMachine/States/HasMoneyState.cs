namespace VendingMachine
{
    public class HasMoneyState : IState
    {
        public HasMoneyState()
        {
            Console.WriteLine("Currently Vending machine is in HasMoneyState");
        }

        public void ClickOnInsertCoinButton(VendingMachine machine)
        {
            // No action needed
        }

        public void ClickOnStartProductSelectionButton(VendingMachine machine)
        {
            machine.SetVendingMachineState(new SelectionState());
        }

        public void InsertCoin(VendingMachine machine, Coin coin)
        {
            Console.WriteLine($"Accepted the coin of value {(int)coin}");
            machine.GetCoinList().Add(coin);
        }

        public void ChooseProduct(VendingMachine machine, int codeNumber)
        {
            throw new Exception("You need to click on start product selection button first");
        }

        public int GetChange(int returnChangeMoney)
        {
            throw new Exception("You cannot get change in HasMoney state");
        }

        public Item DispenseProduct(VendingMachine machine, int codeNumber)
        {
            throw new Exception("Product cannot be dispensed in HasMoney state");
        }

        public List<Coin> RefundFullMoney(VendingMachine machine)
        {
            Console.WriteLine("Returned the full amount back in the Coin Dispense Tray");
            machine.SetVendingMachineState(new IdleState(machine));
            return machine.GetCoinList();
        }

        public void UpdateInventory(VendingMachine machine, Item item, int codeNumber)
        {
            throw new Exception("You cannot update inventory in HasMoney state");
        }
    }
}