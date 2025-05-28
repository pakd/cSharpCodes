namespace VendingMachine
{
    public class ItemShelf
    {
        public int Code { get; set; }
        public Item Item { get; set; }
        public bool SoldOut { get; set; }
    }
}