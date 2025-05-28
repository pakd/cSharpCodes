namespace VendingMachine
{
    using System;
    using System.Collections.Generic;

    public class IdleState : IState
    {
        public IdleState()
        {
            Console.WriteLine("Currently Vending machine is in IdleState");
        }

        public IdleState(VendingMachine machine)
        {
            Console.WriteLine("Currently Vending machine is in IdleState");
            machine.SetCoinList(new List<Coin>());
        }

        public void ClickOnInsertCoinButton(VendingMachine machine)
        {
            machine.SetCoinList(new List<Coin>());
            machine.SetVendingMachineState(new HasMoneyState());
        }

        public void ClickOnStartProductSelectionButton(VendingMachine machine)
        {
            throw new Exception("First you need to click on insert coin button");
        }

        public void InsertCoin(VendingMachine machine, Coin coin)
        {
            throw new Exception("You cannot insert coin in idle state");
        }

        public void ChooseProduct(VendingMachine machine, int codeNumber)
        {
            throw new Exception("You cannot choose product in idle state");
        }

        public int GetChange(int returnChangeMoney)
        {
            throw new Exception("You cannot get change in idle state");
        }

        public List<Coin> RefundFullMoney(VendingMachine machine)
        {
            throw new Exception("You cannot get refunded in idle state");
        }

        public Item DispenseProduct(VendingMachine machine, int codeNumber)
        {
            throw new Exception("Product cannot be dispensed in idle state");
        }

        public void UpdateInventory(VendingMachine machine, Item item, int codeNumber)
        {
            machine.GetInventory().AddItem(item, codeNumber);
        }
    }

}