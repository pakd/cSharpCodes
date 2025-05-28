namespace VendingMachine
{
    public interface IState
    {
        void ClickOnInsertCoinButton(VendingMachine machine);
        void ClickOnStartProductSelectionButton(VendingMachine machine);
        void InsertCoin(VendingMachine machine, Coin coin);
        void ChooseProduct(VendingMachine machine, int codeNumber);
        int GetChange(int returnChangeMoney);
        Item DispenseProduct(VendingMachine machine, int codeNumber);
        List<Coin> RefundFullMoney(VendingMachine machine);
        void UpdateInventory(VendingMachine machine, Item item, int codeNumber);
    }
}