namespace VendingMachine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();

            try
            {
                Console.WriteLine("|");
                Console.WriteLine("Filling up the inventory");
                Console.WriteLine("|");

                FillUpInventory(vendingMachine);
                DisplayInventory(vendingMachine);

                Console.WriteLine("|");
                Console.WriteLine("Clicking on InsertCoinButton");
                Console.WriteLine("|");

                var vendingState = vendingMachine.GetVendingMachineState();
                vendingState.ClickOnInsertCoinButton(vendingMachine);

                vendingState = vendingMachine.GetVendingMachineState();
                vendingState.InsertCoin(vendingMachine, Coin.Nickel);
                vendingState.InsertCoin(vendingMachine, Coin.Quarter);
                // vendingState.InsertCoin(vendingMachine, Coin.Nickel);

                Console.WriteLine("|");
                Console.WriteLine("Clicking on ProductSelectionButton");
                Console.WriteLine("|");
                vendingState.ClickOnStartProductSelectionButton(vendingMachine);

                vendingState = vendingMachine.GetVendingMachineState();
                vendingState.ChooseProduct(vendingMachine, 102);

                DisplayInventory(vendingMachine);
            }
            catch (Exception)
            {
                DisplayInventory(vendingMachine);
            }
        }

        private static void FillUpInventory(VendingMachine vendingMachine)
        {
            ItemShelf[] slots = vendingMachine.GetInventory().GetInventory();
            for (int i = 0; i < slots.Length; i++)
            {
                Item newItem = new Item();
                if (i >= 0 && i < 3)
                {
                    newItem.Type = ItemType.COKE;
                    newItem.Price = 12;
                }
                else if (i >= 3 && i < 5)
                {
                    newItem.Type = ItemType.PEPSI;
                    newItem.Price = 9;
                }
                else if (i >= 5 && i < 7)
                {
                    newItem.Type = ItemType.JUICE;
                    newItem.Price = 13;
                }
                else if (i >= 7 && i < 10)
                {
                    newItem.Type = ItemType.SODA;
                    newItem.Price = 7;
                }

                slots[i].Item = newItem;
                slots[i].SoldOut = false;
            }
        }

        private static void DisplayInventory(VendingMachine vendingMachine)
        {
            ItemShelf[] slots = vendingMachine.GetInventory().GetInventory();
            for (int i = 0; i < slots.Length; i++)
            {
                Console.WriteLine($"CodeNumber: {slots[i].Code} " +
                                  $"Item: {slots[i].Item.Type} " +
                                  $"Price: {slots[i].Item.Price} " +
                                  $"isAvailable: {!slots[i].SoldOut}");
            }
        }
    }
}