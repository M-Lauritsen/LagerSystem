namespace LagerSystem.Models
{
    public class PalletItems
    {
        public int PalletId { get; set; }
        public Pallet Pallet { get; set; }

        public int StockItemId { get; set; }
        public StockItem StockItem { get; set; }

        public int Amount { get; set; }
    }
}
