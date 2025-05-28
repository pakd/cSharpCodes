namespace VendingMachine
{
    public class VendingMachine
    {
        private IState vendingMachineState;
        private Inventory inventory;
        private List<Coin> coinList;

        public VendingMachine()
        {
            vendingMachineState = new IdleState();
            inventory = new Inventory(10);
            coinList = new List<Coin>();
        }

        public IState GetVendingMachineState()
        {
            return vendingMachineState;
        }

        public void SetVendingMachineState(IState vendingMachineState)
        {
            this.vendingMachineState = vendingMachineState;
        }

        public Inventory GetInventory()
        {
            return inventory;
        }

        public void SetInventory(Inventory inventory)
        {
            this.inventory = inventory;
        }

        public List<Coin> GetCoinList()
        {
            return coinList;
        }

        public void SetCoinList(List<Coin> coinList)
        {
            this.coinList = coinList;
        }
    }
}