namespace VendingMachine
{
    public class Inventory
    {
        private ItemShelf[] inventory;

        public Inventory(int itemCount)
        {
            inventory = new ItemShelf[itemCount];
            InitializeEmptyInventory();
        }

        public ItemShelf[] GetInventory()
        {
            return inventory;
        }

        public void SetInventory(ItemShelf[] inventory)
        {
            this.inventory = inventory;
        }

        private void InitializeEmptyInventory()
        {
            int startCode = 101;
            for (int i = 0; i < inventory.Length; i++)
            {
                var space = new ItemShelf
                {
                    Code = startCode,
                    SoldOut = true
                };
                inventory[i] = space;
                startCode++;
            }
        }

        public void AddItem(Item item, int codeNumber)
        {
            foreach (var itemShelf in inventory)
            {
                if (itemShelf.Code == codeNumber)
                {
                    if (itemShelf.SoldOut)
                    {
                        itemShelf.Item = item;
                        itemShelf.SoldOut = false;
                        return;
                    }
                    else
                    {
                        throw new Exception("Item is already present, you cannot add item here");
                    }
                }
            }

            throw new Exception("Code number not found in inventory");
        }

        public Item GetItem(int codeNumber)
        {
            foreach (var itemShelf in inventory)
            {
                if (itemShelf.Code == codeNumber)
                {
                    if (itemShelf.SoldOut)
                    {
                        throw new Exception("Item is already sold out");
                    }
                    else
                    {
                        return itemShelf.Item;
                    }
                }
            }

            throw new Exception("Invalid Code");
        }

        public void UpdateSoldOutItem(int codeNumber)
        {
            foreach (var itemShelf in inventory)
            {
                if (itemShelf.Code == codeNumber)
                {
                    itemShelf.SoldOut = true;
                    return;
                }
            }
        }
    }
}