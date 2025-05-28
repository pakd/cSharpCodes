namespace VendingMachine
{
    public class DispenseState : IState
    {
        public DispenseState(VendingMachine machine, int codeNumber)
        {
            Console.WriteLine("Currently Vending machine is in DispenseState");
            DispenseProduct(machine, codeNumber);
        }

        public void ClickOnInsertCoinButton(VendingMachine machine)
        {
            throw new Exception("Insert coin button cannot be clicked in Dispense state");
        }

        public void ClickOnStartProductSelectionButton(VendingMachine machine)
        {
            throw new Exception("Product selection button cannot be clicked in Dispense state");
        }

        public void InsertCoin(VendingMachine machine, Coin coin)
        {
            throw new Exception("Coin cannot be inserted in Dispense state");
        }

        public void ChooseProduct(VendingMachine machine, int codeNumber)
        {
            throw new Exception("Product cannot be chosen in Dispense state");
        }

        public int GetChange(int returnChangeMoney)
        {
            throw new Exception("Change cannot be returned in Dispense state");
        }

        public List<Coin> RefundFullMoney(VendingMachine machine)
        {
            throw new Exception("Refund cannot happen in Dispense state");
        }

        public Item DispenseProduct(VendingMachine machine, int codeNumber)
        {
            Console.WriteLine("Product has been dispensed");
            Item item = machine.GetInventory().GetItem(codeNumber);
            machine.GetInventory().UpdateSoldOutItem(codeNumber);
            machine.SetVendingMachineState(new IdleState(machine));
            return item;
        }

        public void UpdateInventory(VendingMachine machine, Item item, int codeNumber)
        {
            throw new Exception("Inventory cannot be updated in Dispense state");
        }
    }
}